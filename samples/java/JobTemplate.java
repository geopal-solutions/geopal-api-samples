package GeopalJobSample;

public class JobTemplate
{
	private String privateid;
	public final String getid()
	{
		return privateid;
	}
	public final void setid(String value)
	{
		privateid = value;
	}
	private String privatename;
	public final String getname()
	{
		return privatename;
	}
	public final void setname(String value)
	{
		privatename = value;
	}
	private String privateestimate_job_duration;
	public final String getestimate_job_duration()
	{
		return privateestimate_job_duration;
	}
	public final void setestimate_job_duration(String value)
	{
		privateestimate_job_duration = value;
	}
	private String privatedefault_rate_per_hour;
	public final String getdefault_rate_per_hour()
	{
		return privatedefault_rate_per_hour;
	}
	public final void setdefault_rate_per_hour(String value)
	{
		privatedefault_rate_per_hour = value;
	}
	private String privatepriority_list;
	public final String getpriority_list()
	{
		return privatepriority_list;
	}
	public final void setpriority_list(String value)
	{
		privatepriority_list = value;
	}
	private String privatedescription;
	public final String getdescription()
	{
		return privatedescription;
	}
	public final void setdescription(String value)
	{
		privatedescription = value;
	}
	private String privatecompany_id;
	public final String getcompany_id()
	{
		return privatecompany_id;
	}
	public final void setcompany_id(String value)
	{
		privatecompany_id = value;
	}
	private String privatereview_job;
	public final String getreview_job()
	{
		return privatereview_job;
	}
	public final void setreview_job(String value)
	{
		privatereview_job = value;
	}
	private String privateis_deleted;
	public final String getis_deleted()
	{
		return privateis_deleted;
	}
	public final void setis_deleted(String value)
	{
		privateis_deleted = value;
	}
	private String privateupdated_by;
	public final String getupdated_by()
	{
		return privateupdated_by;
	}
	public final void setupdated_by(String value)
	{
		privateupdated_by = value;
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
	private String privatecreated_by;
	public final String getcreated_by()
	{
		return privatecreated_by;
	}
	public final void setcreated_by(String value)
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
	private java.util.ArrayList<JobTemplateField> privatejob_template_fields;
	public final java.util.ArrayList<JobTemplateField> getjob_template_fields()
	{
		return privatejob_template_fields;
	}
	public final void setjob_template_fields(java.util.ArrayList<JobTemplateField> value)
	{
		privatejob_template_fields = value;
	}
	private java.util.ArrayList<JobTemplateWorkflow> privatejob_template_workflows;
	public final java.util.ArrayList<JobTemplateWorkflow> getjob_template_workflows()
	{
		return privatejob_template_workflows;
	}
	public final void setjob_template_workflows(java.util.ArrayList<JobTemplateWorkflow> value)
	{
		privatejob_template_workflows = value;
	}
}