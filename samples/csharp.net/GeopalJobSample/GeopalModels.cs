using System;
using System.Collections.Generic;
using System.Text;

namespace GeopalJobSample
{

	public class GeopalRequest
	{
		public String status { get; set; }
		public Company company { get; set; }
	}
	
	public class GeopalRequestJobIds : GeopalRequest
	{
		public IEnumerable<JobJustId> jobs { get; set; }
	}
	
	
	public class GeopalRequestJob : GeopalRequest
	{
		public Job job { get; set; }
	}

	public class GeopalRequestJobTemplates : GeopalRequest
	{
		public IEnumerable<JobTemplateSimple> job_templates { get; set; }
	}

	public class GeopalRequestJobTemplate : GeopalRequest
	{
		public JobTemplate job_template { get; set; }
	}

	public class GeopalRequestEmployees : GeopalRequest
	{
		public IEnumerable<Employee> employees { get; set; }
	}
	

	public class Company
	{
		public String id { get; set; }
		public String name { get; set; }
	}
	
	public class Person
	{
		public String id { get; set; }
		public String identifier { get; set; }
		public String title { get; set; }
		public String first_name { get; set; }
		public String last_name { get; set; }
		public String mobile_number { get; set; }
		public String phone_number { get; set; }
		public String phone_number_alternate { get; set; }
		public String fax_number { get; set; }
		public String email { get; set; }
		public String updated_on { get; set; }
	}
	
	public class Address
	{
		public String id { get; set; }
		public String identifier { get; set; }
		public String address_line_1 { get; set; }
		public String address_line_2 { get; set; }
		public String address_line_3 { get; set; }
		public String city { get; set; }
		public String postal_code { get; set; }
		public String country_id { get; set; }
		public String lat { get; set; }
		public String lng { get; set; }
		public String coordinates_verified { get; set; }
		public String updated_on { get; set; }
	}
	
	public class Customer
	{
		public String id { get; set; }
		public String identifier { get; set; }
		public String name { get; set; }
		public String updated_on { get; set; }
	}
	
	public class JobTemplate
	{
		public String id { get; set; }
		public String name { get; set; }
		public String estimate_job_duration { get; set; }
		public String default_rate_per_hour { get; set; }
		public String priority_list { get; set; }
		public String description { get; set; }
		public String company_id { get; set; }
		public String review_job { get; set; }
		public String is_deleted { get; set; }
		public String updated_by { get; set; }
		public String updated_on { get; set; }
		public String created_by { get; set; }
		public String created_on { get; set; }
		public List<JobTemplateField> job_template_fields { get; set; }
		public List<JobTemplateWorkflow> job_template_workflows { get; set; }
	}

	public class JobTemplateSimple
	{
		public String job_template_id { get; set; }
		public String name { get; set; }
		public bool is_deleted { get; set; }
		public String updated_on { get; set; }
	}
	
	
	public class Employee
	{
		public int id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string mobile_number { get; set; }
		public string lat { get; set; }
		public string lng { get; set; }
		public string address { get; set; }
		public string last_updated_on { get; set; }
	}

	
	public class JobJustId
	{
		public String id { get; set; }
	}
	
	
	public class CreatedBy
	{
		public int id { get; set; }
		public string title { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
	}
	
	public class JobWorkflow
	{
		public int id { get; set; }
		public int job_id { get; set; }
		public object employee_id { get; set; }
		public int template_workflow_id { get; set; }
		public string name { get; set; }
		public string action { get; set; }
		public int optional { get; set; }
		public string action_values { get; set; }
		public string action_value_entered { get; set; }
		public int nested_workflow_id { get; set; }
		public int? lat { get; set; }
		public int? lng { get; set; }
		public string done_at { get; set; }
		public string done_by { get; set; }
		public string created_on { get; set; }
		public string updated_on { get; set; }
		public bool done { get; set; }
		public List<JobWorkflowFile> job_workflow_files { get; set; }
	}
	
	public class JobField
	{
		public int id { get; set; }
		public int job_id { get; set; }
		public int template_field_id { get; set; }
		public string name { get; set; }
		public string action { get; set; }
		public string action_values { get; set; }
		public string action_value_entered { get; set; }
		public string done_at { get; set; }
		public string done_by { get; set; }
		public string created_on { get; set; }
		public string updated_on { get; set; }
	}
	
	public class JobWorkflowFile
	{
		public int id { get; set; }
		public int job_id { get; set; }
		public int job_workflow_id { get; set; }
		public int s3file_id { get; set; }
		public int s3file_thumbnail_id { get; set; }
		public string file_name { get; set; }
		public string file_mime_type { get; set; }
		public string link_2_file { get; set; }
		public string link_2_file_thumbnail { get; set; }
		public string uploaded_from { get; set; }
		public int done_by { get; set; }
		public string created_on { get; set; }
		public object updated_on { get; set; }
	}
	
	public class JobStatusChangeMessage
	{
		public int id { get; set; }
		public int job_id { get; set; }
		public int job_status_id { get; set; }
		public string message { get; set; }
		public int company_id { get; set; }
		public int created_by { get; set; }
		public string created_on { get; set; }
		public string done_at { get; set; }
		public string updated_on { get; set; }
	}
	
	public class Job
	{
		public int id { get; set; }
		public string schedule_log_id { get; set; }
		public string schedule_job_status_id { get; set; }
		public string identifier { get; set; }
		public int estimated_duration { get; set; }
		public int rate_per_hour { get; set; }
		public int job_status_id { get; set; }
		public string start_date { get; set; }
		public string start_time { get; set; }
		public string start_date_time { get; set; }
		public string prefered_start_date_time { get; set; }
		public string prefered_stop_date_time { get; set; }
		public string duration { get; set; }
		public string priority_text { get; set; }
		public string priority_color { get; set; }
		public Company company { get; set; }
		public Person person { get; set; }
		public Address address { get; set; }
		public Customer customer { get; set; }
		public JobTemplate job_template { get; set; }
		public string notes { get; set; }
		public Employee employee { get; set; }
		public CreatedBy created_by { get; set; }
		public string created_on { get; set; }
		public string updated_on { get; set; }
		public string assigned_at { get; set; }
		public string end_time { get; set; }
		public List<JobWorkflow> job_workflows { get; set; }
		public List<JobField> job_fields { get; set; }
		public List<JobWorkflowFile> job_workflow_files { get; set; }
		public List<object> job_field_files { get; set; }
		public string job_assigned_to { get; set; }
		public List<JobStatusChangeMessage> job_status_change_messages { get; set; }
	}

	public class JobTemplateField
	{
		public int id { get; set; }
		public string template_id { get; set; }
		public string name { get; set; }
		public string action { get; set; }
		public string action_values { get; set; }
		public string include_in_reports { get; set; }
		public string order_number { get; set; }
		public string is_deleted { get; set; }
		public string updated_on { get; set; }
		public string created_on { get; set; }
		public string updated_at { get; set; }
	}
	
	public class JobTemplateWorkflow
	{
		public int id { get; set; }
		public string template_id { get; set; }
		public string name { get; set; }
		public string action { get; set; }
		public string optional { get; set; }
		public string action_value_entered { get; set; }
		public string nested_workflow_id { get; set; }
		public string include_in_reports { get; set; }
		public string level_number { get; set; }
		public string order_number { get; set; }
		public string is_deleted { get; set; }
		public string updated_on { get; set; }
		public string created_on { get; set; }
		public string updated_at { get; set; }
	}
}

