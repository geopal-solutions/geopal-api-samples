Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Collections.Specialized
Imports System.IO
Imports Newtonsoft.Json
Imports System.Xml
Imports System.Web
Imports System.Web.Services

Namespace GeopalJobSample
    Class MainClass

        Private Shared employeeId As String = ""
        Private Shared privateKey As String = ""

        Public Shared Sub Main(args As String())
            Console.WriteLine("Geopal Sample")
            Console.WriteLine("Please Enter Employee ID:")
            employeeId = Console.ReadLine()

            Console.WriteLine("Please Enter Private Key:")
            privateKey = Console.ReadLine()

            Dim choice As Integer = 0
            While choice <> -1
                Console.WriteLine("")
                Console.WriteLine("")
                Console.WriteLine("")
                Console.WriteLine("---------------------------------------------------------")
                Console.WriteLine("Create A Job: 1")
                Console.WriteLine("Read A Job: 2")
                Console.WriteLine("List All Job Templates: 3")
                Console.WriteLine("Read Job Template: 4")
                Console.WriteLine("Read Jobs Between Date Rage: 5")
                Console.WriteLine("List Employees: 6")
                Console.WriteLine("List Employees, but convert json output to xml: 7")
                Console.WriteLine("Please Choose")

                choice = ReadInt()

                Select Case choice
                    Case 1
                        CreateAJob()
                        Exit Select
                    Case 2
                        ReadAJob()
                        Exit Select
                    Case 3
                        ListTemplates()
                        Exit Select
                    Case 4
                        ReadTemplate()
                        Exit Select
                    Case 5
                        ReadJobsDateRange()
                        Exit Select
                    Case 6
                        ListEmployess()
                        Exit Select
                    Case 7
                        Dim doConver2Xml = True
                        ListEmployess(doConver2Xml)
                        Exit Select
                    Case Else
                        Console.WriteLine("Invalid Choice")
                        Exit Select
                End Select
            End While
        End Sub

        '*
'        * Creates a job returns outputs the job identifer
'        * 
'        * No error checking
'        * 
'        * 
'        *

        Private Shared Sub CreateAJob()
            Console.WriteLine("Please enter a job template id")
            Dim jobTemplateId As String = Console.ReadLine()
            Dim geopalClient As New GeopalClient("api/jobs/createandassign")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)

            Dim pairs As New NameValueCollection()
            pairs.Add("template_id", jobTemplateId)
            Dim response As [String] = geopalClient.post(pairs)

            Dim geopalRequestJob As GeopalRequestJob = JsonConvert.DeserializeObject(Of GeopalRequestJob)(response)
            Console.WriteLine("Created Job With Identifier = " & geopalRequestJob.job.identifier)
            Console.WriteLine("Created Job With Id = " & geopalRequestJob.job.id)
        End Sub

        '*
'        * Reads in a job via an indternal job id.
'        * 
'        * To get a job by an identifier use getbyidentifier
'        * 
'        * No error checking
'        * 
'        * 
'        *

        Private Shared Sub ReadAJob()
            Console.WriteLine("Please enter a job id")
            Dim jobId As String = Console.ReadLine()
            ReadAJob(jobId)
        End Sub

        Private Shared Sub ReadAJob(jobId As String)
            Dim geopalClient As New GeopalClient("api/jobs/get")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            Dim response As [String] = geopalClient.[get]("job_id=" & jobId)
            Dim geopalRequestJob As GeopalRequestJob = JsonConvert.DeserializeObject(Of GeopalRequestJob)(response)
            Console.WriteLine("Job Identifier: " & geopalRequestJob.job.identifier)
            Console.WriteLine("Job Template: " & geopalRequestJob.job.job_template.name)

            Console.WriteLine(vbLf & "Job Fields")
            For Each jobField As JobField In geopalRequestJob.job.job_fields
                Console.WriteLine((jobField.name & " (" & jobField.id & "): ") & jobField.action_value_entered)
            Next

            Console.WriteLine(vbLf & "Job Workflows")
            For Each jobWorkflow As JobWorkflow In geopalRequestJob.job.job_workflows
                Console.WriteLine((jobWorkflow.name & " (" & jobWorkflow.id & "): ") & jobWorkflow.action_value_entered)
                For Each jobWorkflowFile As JobWorkflowFile In jobWorkflow.job_workflow_files
                    Console.WriteLine((jobWorkflowFile.file_name & " (" & jobWorkflowFile.id & "): s3 file id ") & jobWorkflowFile.s3file_id)
                    DownloadS3File(jobWorkflowFile.s3file_id)
                Next
            Next

        End Sub


        '*
'        * Simple function to download a an s3 file, note tmp dir is hardcoded, file name is hardcoded
'        * 
'        * No error checking
'        * 
'        * 
'        *

        Private Shared Sub DownloadS3File(s3fileId As Integer)
            Dim geopalClient As New GeopalClient("api/s3files/get")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            geopalClient.downloadFile("s3_file_id=" & s3fileId, "/tmp/" & s3fileId & ".jpg")
        End Sub


        '*
'        * Lists all job templates on your account
'        * 
'        * No error checking
'        * 
'        * 
'        *

        Private Shared Sub ListTemplates()
            Dim geopalClient As New GeopalClient("api/jobtemplates/all")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            Dim response As [String] = geopalClient.[get]()
            Dim geopalRequestJobTemplates As GeopalRequestJobTemplates = JsonConvert.DeserializeObject(Of GeopalRequestJobTemplates)(response)
            For Each jobTemplateSimple As JobTemplateSimple In geopalRequestJobTemplates.job_templates
                If jobTemplateSimple.is_deleted = False Then
                    Console.WriteLine(jobTemplateSimple.name & " (" & jobTemplateSimple.job_template_id & ")")
                End If
            Next
        End Sub

        '*
'        *  Shows in detail a job template
'        * 
'        * No error checking
'        * 
'        * 
'        *

        Private Shared Sub ReadTemplate()
            Console.WriteLine("Please enter a job template id")
            Dim jobTemplateId As String = Console.ReadLine()
            Dim geopalClient As New GeopalClient("api/jobtemplates/get")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            Dim response As [String] = geopalClient.[get]("template_id=" & jobTemplateId)
            Dim geopalRequestJobTemplate As GeopalRequestJobTemplate = JsonConvert.DeserializeObject(Of GeopalRequestJobTemplate)(response)
            Console.WriteLine("Job Template Name = " & geopalRequestJobTemplate.job_template.name)
            Console.WriteLine(vbLf & "Job Fields")
            For Each jobTemplateField As JobTemplateField In geopalRequestJobTemplate.job_template.job_template_fields
                Console.WriteLine(jobTemplateField.name & " (" & jobTemplateField.id & ")")
            Next

            Console.WriteLine(vbLf & "Job Workflows")
            For Each jobTemplateWorkflow As JobTemplateWorkflow In geopalRequestJobTemplate.job_template.job_template_workflows
                Console.WriteLine((jobTemplateWorkflow.name & " (" & jobTemplateWorkflow.id & ") [") & jobTemplateWorkflow.action & "]")
            Next
        End Sub



        '*
'        * Reads in jobs over a date range
'        * 
'        * Note error checking
'        * 
'        * 
'        *

        Private Shared Sub ReadJobsDateRange()
            Console.WriteLine("Please enter a from date (YYYY-MM-DD HH:II:SS)")
            Dim dateTimeFrom As String = Console.ReadLine()
            dateTimeFrom = HttpUtility.UrlEncode(dateTimeFrom)
            Console.WriteLine("Please enter a to date (YYYY-MM-DD HH:II:SS)")
            Dim dateTimeTo As String = Console.ReadLine()
            dateTimeTo = HttpUtility.UrlEncode(dateTimeTo)
            Dim geopalClient As New GeopalClient("api/jobsearch/ids")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            Dim response As [String] = geopalClient.[get]("date_time_from=" & dateTimeFrom & "&date_time_to=" & dateTimeTo)
            Dim geopalRequestJobIds As GeopalRequestJobIds = JsonConvert.DeserializeObject(Of GeopalRequestJobIds)(response)
            For Each jobJustId As JobJustId In geopalRequestJobIds.jobs
                Console.WriteLine("Job Id: " & jobJustId.id)
                ReadAJob(jobJustId.id)
            Next
        End Sub

        '*
'        * Shows a list of current active employees, or converts json output to xml as an example
'        * 
'        * No error checking
'        * 
'        *

        Private Shared Sub ListEmployess(Optional convert2Xml As Boolean = False)
            Dim geopalClient As New GeopalClient("api/employees/all")
            geopalClient.setEmployeeId(employeeId)
            geopalClient.setPrivateKey(privateKey)
            Dim response As [String] = geopalClient.[get]()
            If convert2Xml Then
                Dim doc As XmlDocument = DirectCast(JsonConvert.DeserializeXmlNode(response, "employees"), XmlDocument)
                Console.WriteLine(doc.OuterXml)
            Else
                Dim geopalRequestEmployees As GeopalRequestEmployees = JsonConvert.DeserializeObject(Of GeopalRequestEmployees)(response)
                For Each employee As Employee In geopalRequestEmployees.employees
                    Console.WriteLine(((employee.first_name & " " & employee.last_name & " (") & employee.id & ") ") & employee.address)
                Next
            End If
        End Sub


        '*
'        * Helper function to read in an int
'        * 
'        * 
'        *

        Private Shared Function ReadInt() As Integer
            Dim choice As Integer = 0
            Try
                choice = Convert.ToInt32(Console.ReadLine())
            Catch e As FormatException
                choice = -1
            End Try
            Return choice
        End Function


    End Class
End Namespace
