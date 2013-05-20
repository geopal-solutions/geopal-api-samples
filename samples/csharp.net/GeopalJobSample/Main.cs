using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Web;
using System.Web.Services;

namespace GeopalJobSample
{
	class MainClass
	{

		private static string employeeId = "";
		private static string privateKey = "";

		public static void Main (string[] args)
		{
			Console.WriteLine ("Geopal Sample");
			Console.WriteLine ("Please Enter Employee ID:");
			employeeId = Console.ReadLine();

			Console.WriteLine ("Please Enter Private Key:");
			privateKey = Console.ReadLine();

			int choice = 0;
			while (choice != -1) {
				Console.WriteLine ("");
				Console.WriteLine ("");
				Console.WriteLine ("");
				Console.WriteLine ("---------------------------------------------------------");
				Console.WriteLine ("Create A Job: 1");
				Console.WriteLine ("Read A Job: 2");
				Console.WriteLine ("List All Job Templates: 3");
				Console.WriteLine ("Read Job Template: 4");
				Console.WriteLine ("Read Jobs Between Date Rage: 5");
				Console.WriteLine ("List Employees: 6");
				Console.WriteLine ("List Employees, but convert json output to xml: 7");
				Console.WriteLine ("Please Choose");

				choice = ReadInt();

				switch (choice) {
				case 1:
					CreateAJob ();
					break;
				case 2:
					ReadAJob ();
					break;
				case 3:
					ListTemplates ();
					break;
				case 4:
					ReadTemplate ();
					break;
				case 5:
					ReadJobsDateRange ();
					break;
				case 6:
					ListEmployess();
					break;
				case 7:
					var doConver2Xml = true;
					ListEmployess(doConver2Xml);
					break;
				default:
					Console.WriteLine ("Invalid Choice");
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
		private static void CreateAJob ()
		{
			Console.WriteLine ("Please enter a job template id");
			string jobTemplateId = Console.ReadLine();
			GeopalClient geopalClient = new GeopalClient("api/jobs/createandassign");
			geopalClient.setEmployeeId(employeeId);
			geopalClient.setPrivateKey(privateKey);

			NameValueCollection pairs = new NameValueCollection();
			pairs.Add("template_id", jobTemplateId);
			String response = geopalClient.post(pairs);

			GeopalRequestJob geopalRequestJob = JsonConvert.DeserializeObject<GeopalRequestJob>(response);
			Console.WriteLine("Created Job With Identifier = "+geopalRequestJob.job.identifier);
			Console.WriteLine("Created Job With Id = "+geopalRequestJob.job.id);
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
		private static void ReadAJob ()
		{
			Console.WriteLine ("Please enter a job id");
			string jobId = Console.ReadLine();
			ReadAJob(jobId);
		}

		private static void ReadAJob (string jobId)
		{
			GeopalClient geopalClient = new GeopalClient("api/jobs/get");
			geopalClient.setEmployeeId(employeeId);
			geopalClient.setPrivateKey(privateKey);
			String response = geopalClient.get("job_id="+jobId);
			GeopalRequestJob geopalRequestJob = JsonConvert.DeserializeObject<GeopalRequestJob>(response);
			Console.WriteLine("Job Identifier: "+geopalRequestJob.job.identifier);
			Console.WriteLine("Job Template: "+geopalRequestJob.job.job_template.name);
			
			Console.WriteLine("\nJob Fields");
			foreach(JobField jobField in geopalRequestJob.job.job_fields) {
				Console.WriteLine(jobField.name + " (" + jobField.id + "): " + jobField.action_value_entered );
			}
			
			Console.WriteLine("\nJob Workflows");
			foreach(JobWorkflow jobWorkflow in geopalRequestJob.job.job_workflows) {
				Console.WriteLine(jobWorkflow.name + " (" + jobWorkflow.id + "): " + jobWorkflow.action_value_entered );
				foreach(JobWorkflowFile jobWorkflowFile in jobWorkflow.job_workflow_files) {
					Console.WriteLine(jobWorkflowFile.file_name + " (" + jobWorkflowFile.id + "): s3 file id " + jobWorkflowFile.s3file_id );
					DownloadS3File(jobWorkflowFile.s3file_id);
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
		private static void DownloadS3File (int s3fileId)
		{
			GeopalClient geopalClient = new GeopalClient("api/s3files/get");
			geopalClient.setEmployeeId(employeeId);
			geopalClient.setPrivateKey(privateKey);
			geopalClient.downloadFile("s3_file_id="+s3fileId, "/tmp/" + s3fileId + ".jpg");
		}


		/**
		 * Lists all job templates on your account
		 * 
		 * No error checking
		 * 
		 * 
		 **/
		private static void ListTemplates ()
		{
			GeopalClient geopalClient = new GeopalClient("api/jobtemplates/all");
			geopalClient.setEmployeeId(employeeId);
			geopalClient.setPrivateKey(privateKey);
			String response = geopalClient.get();
			GeopalRequestJobTemplates geopalRequestJobTemplates = JsonConvert.DeserializeObject<GeopalRequestJobTemplates>(response);
			foreach(JobTemplateSimple jobTemplateSimple in geopalRequestJobTemplates.job_templates) {
				if (jobTemplateSimple.is_deleted == false) {
					Console.WriteLine(jobTemplateSimple.name + " (" + jobTemplateSimple.job_template_id + ")" );
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
		private static void ReadTemplate ()
		{
			Console.WriteLine ("Please enter a job template id");
			string jobTemplateId = Console.ReadLine();
			GeopalClient geopalClient = new GeopalClient("api/jobtemplates/get");
			geopalClient.setEmployeeId(employeeId);
			geopalClient.setPrivateKey(privateKey);
			String response = geopalClient.get("template_id="+jobTemplateId);
			GeopalRequestJobTemplate geopalRequestJobTemplate = JsonConvert.DeserializeObject<GeopalRequestJobTemplate>(response);
			Console.WriteLine("Job Template Name = " + geopalRequestJobTemplate.job_template.name);
			Console.WriteLine("\nJob Fields");
			foreach(JobTemplateField jobTemplateField in geopalRequestJobTemplate.job_template.job_template_fields) {
				Console.WriteLine(jobTemplateField.name + " (" + jobTemplateField.id + ")" );
			}

			Console.WriteLine("\nJob Workflows");
			foreach(JobTemplateWorkflow jobTemplateWorkflow in geopalRequestJobTemplate.job_template.job_template_workflows) {
				Console.WriteLine(jobTemplateWorkflow.name + " (" + jobTemplateWorkflow.id + ") ["+jobTemplateWorkflow.action+"]" );
			}
		}



		/**
		 * Reads in jobs over a date range
		 * 
		 * Note error checking
		 * 
		 * 
		 **/
		private static void ReadJobsDateRange ()
		{
			Console.WriteLine ("Please enter a from date (yyyy-MM-dd HH:mm:ss) see http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx");
			string dateTimeFrom = Console.ReadLine ();
			dateTimeFrom = HttpUtility.UrlEncode(dateTimeFrom);
			Console.WriteLine ("Please enter a to date (yyyy-MM-dd HH:mm:ss)");
			string dateTimeTo = Console.ReadLine ();
			dateTimeTo = HttpUtility.UrlEncode(dateTimeTo);
			GeopalClient geopalClient = new GeopalClient ("api/jobsearch/ids");
			geopalClient.setEmployeeId (employeeId);
			geopalClient.setPrivateKey (privateKey);
			String response = geopalClient.get ("date_time_from=" + dateTimeFrom + "&date_time_to=" + dateTimeTo);
			GeopalRequestJobIds geopalRequestJobIds = JsonConvert.DeserializeObject<GeopalRequestJobIds> (response);
			foreach (JobJustId jobJustId in geopalRequestJobIds.jobs) {
				Console.WriteLine("Job Id: " + jobJustId.id);
				ReadAJob(jobJustId.id);
			}
		}

		/**
		 * Shows a list of current active employees, or converts json output to xml as an example
		 * 
		 * No error checking
		 * 
		 **/
		private static void ListEmployess (bool convert2Xml = false)
		{
			GeopalClient geopalClient = new GeopalClient ("api/employees/all");
			geopalClient.setEmployeeId (employeeId);
			geopalClient.setPrivateKey (privateKey);
			String response = geopalClient.get ();
			if (convert2Xml) {
				XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(response, "employees");
				Console.WriteLine(doc.OuterXml);
			} else {
				GeopalRequestEmployees geopalRequestEmployees = JsonConvert.DeserializeObject<GeopalRequestEmployees> (response);
				foreach (Employee employee in geopalRequestEmployees.employees) {
					Console.WriteLine(employee.first_name + " " + employee.last_name + " (" + employee.id + ") " + employee.address);
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
			try {
				choice = Convert.ToInt32 (Console.ReadLine ());
			} catch (FormatException e) {
				choice = -1;
			}
			return choice;
		}


	}
}
