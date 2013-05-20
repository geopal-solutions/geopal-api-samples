package GeopalJobSample;

import java.io.*;
import Newtonsoft.Json.*;

public class MainClass
{

	private static String employeeId = "";
	private static String privateKey = "";

	public static void main(String[] args)
	{
		System.out.println("Geopal Sample");
		System.out.println("Please Enter Employee ID:");
		BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
		employeeId = in.readLine();

		System.out.println("Please Enter Private Key:");
		privateKey = in.readLine();

		int choice = 0;
		while (choice != -1)
		{
			System.out.println("");
			System.out.println("");
			System.out.println("");
			System.out.println("---------------------------------------------------------");
			System.out.println("Create A Job: 1");
			System.out.println("Read A Job: 2");
			System.out.println("List All Job Templates: 3");
			System.out.println("Read Job Template: 4");
			System.out.println("Read Jobs Between Date Rage: 5");
			System.out.println("List Employees: 6");
			System.out.println("List Employees, but convert json output to xml: 7");
			System.out.println("Please Choose");

			choice = ReadInt();

			switch (choice)
			{
			case 1:
				CreateAJob();
				break;
			case 2:
				ReadAJob();
				break;
			case 3:
				ListTemplates();
				break;
			case 4:
				ReadTemplate();
				break;
			case 5:
				ReadJobsDateRange();
				break;
			case 6:
				ListEmployess();
				break;
			case 7:
				boolean doConver2Xml = true;
				ListEmployess(doConver2Xml);
				break;
			default:
				System.out.println("Invalid Choice");
				break;
			}
		}
	}

	/**
	 * Creates a job returns outputs the job identifer
	 * 
	 * No error checking
	 * 
	 * 
	 **/
	private static void CreateAJob()
	{
		System.out.println("Please enter a job template id");
		String jobTemplateId = in.readLine();
		GeopalClient geopalClient = new GeopalClient("api/jobs/createandassign");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);

		NameValueCollection pairs = new NameValueCollection();
		pairs.Add("template_id", jobTemplateId);
		String response = geopalClient.post(pairs);

		GeopalRequestJob geopalRequestJob = JsonConvert.<GeopalRequestJob>DeserializeObject(response);
		System.out.println("Created Job With Identifier = " + geopalRequestJob.getjob().getidentifier());
		System.out.println("Created Job With Id = " + geopalRequestJob.getjob().getid());
	}

	/**
	 * Reads in a job via an indternal job id.
	 * 
	 * To get a job by an identifier use getbyidentifier
	 * 
	 * No error checking
	 * 
	 * 
	 **/
	private static void ReadAJob()
	{
		System.out.println("Please enter a job id");
		String jobId = in.readLine();
		ReadAJob(jobId);
	}

	private static void ReadAJob(String jobId)
	{
		GeopalClient geopalClient = new GeopalClient("api/jobs/get");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		String response = geopalClient.get("job_id=" + jobId);
		GeopalRequestJob geopalRequestJob = JsonConvert.<GeopalRequestJob>DeserializeObject(response);
		System.out.println("Job Identifier: " + geopalRequestJob.getjob().getidentifier());
		System.out.println("Job Template: " + geopalRequestJob.getjob().getjob_template().getname());

		System.out.println("\nJob Fields");
		for (JobField jobField : geopalRequestJob.getjob().getjob_fields())
		{
			System.out.println(jobField.getname() + " (" + jobField.getid() + "): " + jobField.getaction_value_entered());
		}

		System.out.println("\nJob Workflows");
		for (JobWorkflow jobWorkflow : geopalRequestJob.getjob().getjob_workflows())
		{
			System.out.println(jobWorkflow.getname() + " (" + jobWorkflow.getid() + "): " + jobWorkflow.getaction_value_entered());
			for (JobWorkflowFile jobWorkflowFile : jobWorkflow.getjob_workflow_files())
			{
				System.out.println(jobWorkflowFile.getfile_name() + " (" + jobWorkflowFile.getid() + "): s3 file id " + jobWorkflowFile.gets3file_id());
				DownloadS3File(jobWorkflowFile.gets3file_id());
			}
		}

	}


	/**
	 * Simple function to download a an s3 file, note tmp dir is hardcoded, file name is hardcoded
	 * 
	 * No error checking
	 * 
	 * 
	 **/
	private static void DownloadS3File(int s3fileId)
	{
		GeopalClient geopalClient = new GeopalClient("api/s3files/get");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		geopalClient.downloadFile("s3_file_id=" + s3fileId, "/tmp/" + s3fileId + ".jpg");
	}


	/**
	 * Lists all job templates on your account
	 * 
	 * No error checking
	 * 
	 * 
	 **/
	private static void ListTemplates()
	{
		GeopalClient geopalClient = new GeopalClient("api/jobtemplates/all");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		String response = geopalClient.get();
		GeopalRequestJobTemplates geopalRequestJobTemplates = JsonConvert.<GeopalRequestJobTemplates>DeserializeObject(response);
		for (JobTemplateSimple jobTemplateSimple : geopalRequestJobTemplates.getjob_templates())
		{
			if (jobTemplateSimple.getis_deleted() == false)
			{
				System.out.println(jobTemplateSimple.getname() + " (" + jobTemplateSimple.getjob_template_id() + ")");
			}
		}
	}

	/**
	 *  Shows in detail a job template
	 * 
	 * No error checking
	 * 
	 * 
	 **/
	private static void ReadTemplate()
	{
		System.out.println("Please enter a job template id");
		String jobTemplateId = in.readLine();
		GeopalClient geopalClient = new GeopalClient("api/jobtemplates/get");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		String response = geopalClient.get("template_id=" + jobTemplateId);
		GeopalRequestJobTemplate geopalRequestJobTemplate = JsonConvert.<GeopalRequestJobTemplate>DeserializeObject(response);
		System.out.println("Job Template Name = " + geopalRequestJobTemplate.getjob_template().getname());
		System.out.println("\nJob Fields");
		for (JobTemplateField jobTemplateField : geopalRequestJobTemplate.getjob_template().getjob_template_fields())
		{
			System.out.println(jobTemplateField.getname() + " (" + jobTemplateField.getid() + ")");
		}

		System.out.println("\nJob Workflows");
		for (JobTemplateWorkflow jobTemplateWorkflow : geopalRequestJobTemplate.getjob_template().getjob_template_workflows())
		{
			System.out.println(jobTemplateWorkflow.getname() + " (" + jobTemplateWorkflow.getid() + ") [" + jobTemplateWorkflow.getaction() + "]");
		}
	}



	/**
	 * Reads in jobs over a date range
	 * 
	 * Note error checking
	 * 
	 * 
	 **/
	private static void ReadJobsDateRange()
	{
		System.out.println("Please enter a from date (yyyy-MM-dd HH:mm:ss) see http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx");
		String dateTimeFrom = in.readLine();
		dateTimeFrom = HttpUtility.UrlEncode(dateTimeFrom);
		System.out.println("Please enter a to date (yyyy-MM-dd HH:mm:ss)");
		String dateTimeTo = in.readLine();
		dateTimeTo = HttpUtility.UrlEncode(dateTimeTo);
		GeopalClient geopalClient = new GeopalClient("api/jobsearch/ids");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		String response = geopalClient.get("date_time_from=" + dateTimeFrom + "&date_time_to=" + dateTimeTo);
		GeopalRequestJobIds geopalRequestJobIds = JsonConvert.<GeopalRequestJobIds>DeserializeObject (response);
		for (JobJustId jobJustId : geopalRequestJobIds.getjobs())
		{
			System.out.println("Job Id: " + jobJustId.getid());
			ReadAJob(jobJustId.getid());
		}
	}

	/**
	 * Shows a list of current active employees, or converts json output to xml as an example
	 * 
	 * No error checking
	 * 
	 **/

	private static void ListEmployess()
	{
		ListEmployess(false);
	}

//C# TO JAVA CONVERTER NOTE: Java does not support optional parameters. Overloaded method(s) are created above:
//ORIGINAL LINE: private static void ListEmployess(bool convert2Xml = false)
	private static void ListEmployess(boolean convert2Xml)
	{
		GeopalClient geopalClient = new GeopalClient("api/employees/all");
		geopalClient.setEmployeeId(employeeId);
		geopalClient.setPrivateKey(privateKey);
		String response = geopalClient.get();
		if (convert2Xml)
		{
			XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(response, "employees");
			System.out.println(doc.OuterXml);
		}
		else
		{
			GeopalRequestEmployees geopalRequestEmployees = JsonConvert.<GeopalRequestEmployees>DeserializeObject (response);
			for (Employee employee : geopalRequestEmployees.getemployees())
			{
				System.out.println(employee.getfirst_name() + " " + employee.getlast_name() + " (" + employee.getid() + ") " + employee.getaddress());
			}
		}
	}


	/**
	 * Helper function to read in an int
	 * 
	 * 
	 **/
	private static int ReadInt()
	{
		int choice = 0;
		try
		{
			choice = (int)in.readLine();
		}
		catch (FormatException e)
		{
			choice = -1;
		}
		return choice;
	}


}