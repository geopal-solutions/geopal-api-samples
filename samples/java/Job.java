package GeopalJobSample;

public class Job
{
	private int privateid;
	public final int getid()
	{
		return privateid;
	}
	public final void setid(int value)
	{
		privateid = value;
	}
	private String privateschedule_log_id;
	public final String getschedule_log_id()
	{
		return privateschedule_log_id;
	}
	public final void setschedule_log_id(String value)
	{
		privateschedule_log_id = value;
	}
	private String privateschedule_job_status_id;
	public final String getschedule_job_status_id()
	{
		return privateschedule_job_status_id;
	}
	public final void setschedule_job_status_id(String value)
	{
		privateschedule_job_status_id = value;
	}
	private String privateidentifier;
	public final String getidentifier()
	{
		return privateidentifier;
	}
	public final void setidentifier(String value)
	{
		privateidentifier = value;
	}
	private int privateestimated_duration;
	public final int getestimated_duration()
	{
		return privateestimated_duration;
	}
	public final void setestimated_duration(int value)
	{
		privateestimated_duration = value;
	}
	private int privaterate_per_hour;
	public final int getrate_per_hour()
	{
		return privaterate_per_hour;
	}
	public final void setrate_per_hour(int value)
	{
		privaterate_per_hour = value;
	}
	private int privatejob_status_id;
	public final int getjob_status_id()
	{
		return privatejob_status_id;
	}
	public final void setjob_status_id(int value)
	{
		privatejob_status_id = value;
	}
	private String privatestart_date;
	public final String getstart_date()
	{
		return privatestart_date;
	}
	public final void setstart_date(String value)
	{
		privatestart_date = value;
	}
	private String privatestart_time;
	public final String getstart_time()
	{
		return privatestart_time;
	}
	public final void setstart_time(String value)
	{
		privatestart_time = value;
	}
	private String privatestart_date_time;
	public final String getstart_date_time()
	{
		return privatestart_date_time;
	}
	public final void setstart_date_time(String value)
	{
		privatestart_date_time = value;
	}
	private String privateprefered_start_date_time;
	public final String getprefered_start_date_time()
	{
		return privateprefered_start_date_time;
	}
	public final void setprefered_start_date_time(String value)
	{
		privateprefered_start_date_time = value;
	}
	private String privateprefered_stop_date_time;
	public final String getprefered_stop_date_time()
	{
		return privateprefered_stop_date_time;
	}
	public final void setprefered_stop_date_time(String value)
	{
		privateprefered_stop_date_time = value;
	}
	private String privateduration;
	public final String getduration()
	{
		return privateduration;
	}
	public final void setduration(String value)
	{
		privateduration = value;
	}
	private String privatepriority_text;
	public final String getpriority_text()
	{
		return privatepriority_text;
	}
	public final void setpriority_text(String value)
	{
		privatepriority_text = value;
	}
	private String privatepriority_color;
	public final String getpriority_color()
	{
		return privatepriority_color;
	}
	public final void setpriority_color(String value)
	{
		privatepriority_color = value;
	}
	private Company privatecompany;
	public final Company getcompany()
	{
		return privatecompany;
	}
	public final void setcompany(Company value)
	{
		privatecompany = value;
	}
	private Person privateperson;
	public final Person getperson()
	{
		return privateperson;
	}
	public final void setperson(Person value)
	{
		privateperson = value;
	}
	private Address privateaddress;
	public final Address getaddress()
	{
		return privateaddress;
	}
	public final void setaddress(Address value)
	{
		privateaddress = value;
	}
	private Customer privatecustomer;
	public final Customer getcustomer()
	{
		return privatecustomer;
	}
	public final void setcustomer(Customer value)
	{
		privatecustomer = value;
	}
	private JobTemplate privatejob_template;
	public final JobTemplate getjob_template()
	{
		return privatejob_template;
	}
	public final void setjob_template(JobTemplate value)
	{
		privatejob_template = value;
	}
	private String privatenotes;
	public final String getnotes()
	{
		return privatenotes;
	}
	public final void setnotes(String value)
	{
		privatenotes = value;
	}
	private Employee privateemployee;
	public final Employee getemployee()
	{
		return privateemployee;
	}
	public final void setemployee(Employee value)
	{
		privateemployee = value;
	}
	private CreatedBy privatecreated_by;
	public final CreatedBy getcreated_by()
	{
		return privatecreated_by;
	}
	public final void setcreated_by(CreatedBy value)
	{
		privatecreated_by = value;
	}
	private String privatecreated_on;
	public final String getcreated_on()
	{
		return privatecreated_on;
	}
	public final void setcreated_on(String value)
	{
		privatecreated_on = value;
	}
	private String privateupdated_on;
	public final String getupdated_on()
	{
		return privateupdated_on;
	}
	public final void setupdated_on(String value)
	{
		privateupdated_on = value;
	}
	private String privateassigned_at;
	public final String getassigned_at()
	{
		return privateassigned_at;
	}
	public final void setassigned_at(String value)
	{
		privateassigned_at = value;
	}
	private String privateend_time;
	public final String getend_time()
	{
		return privateend_time;
	}
	public final void setend_time(String value)
	{
		privateend_time = value;
	}
	private java.util.ArrayList<JobWorkflow> privatejob_workflows;
	public final java.util.ArrayList<JobWorkflow> getjob_workflows()
	{
		return privatejob_workflows;
	}
	public final void setjob_workflows(java.util.ArrayList<JobWorkflow> value)
	{
		privatejob_workflows = value;
	}
	private java.util.ArrayList<JobField> privatejob_fields;
	public final java.util.ArrayList<JobField> getjob_fields()
	{
		return privatejob_fields;
	}
	public final void setjob_fields(java.util.ArrayList<JobField> value)
	{
		privatejob_fields = value;
	}
	private java.util.ArrayList<JobWorkflowFile> privatejob_workflow_files;
	public final java.util.ArrayList<JobWorkflowFile> getjob_workflow_files()
	{
		return privatejob_workflow_files;
	}
	public final void setjob_workflow_files(java.util.ArrayList<JobWorkflowFile> value)
	{
		privatejob_workflow_files = value;
	}
	private java.util.ArrayList<Object> privatejob_field_files;
	public final java.util.ArrayList<Object> getjob_field_files()
	{
		return privatejob_field_files;
	}
	public final void setjob_field_files(java.util.ArrayList<Object> value)
	{
		privatejob_field_files = value;
	}
	private String privatejob_assigned_to;
	public final String getjob_assigned_to()
	{
		return privatejob_assigned_to;
	}
	public final void setjob_assigned_to(String value)
	{
		privatejob_assigned_to = value;
	}
	private java.util.ArrayList<JobStatusChangeMessage> privatejob_status_change_messages;
	public final java.util.ArrayList<JobStatusChangeMessage> getjob_status_change_messages()
	{
		return privatejob_status_change_messages;
	}
	public final void setjob_status_change_messages(java.util.ArrayList<JobStatusChangeMessage> value)
	{
		privatejob_status_change_messages = value;
	}
}