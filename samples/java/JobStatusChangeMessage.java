package GeopalJobSample;

public class JobStatusChangeMessage
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
	private int privatejob_id;
	public final int getjob_id()
	{
		return privatejob_id;
	}
	public final void setjob_id(int value)
	{
		privatejob_id = value;
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
	private String privatemessage;
	public final String getmessage()
	{
		return privatemessage;
	}
	public final void setmessage(String value)
	{
		privatemessage = value;
	}
	private int privatecompany_id;
	public final int getcompany_id()
	{
		return privatecompany_id;
	}
	public final void setcompany_id(int value)
	{
		privatecompany_id = value;
	}
	private int privatecreated_by;
	public final int getcreated_by()
	{
		return privatecreated_by;
	}
	public final void setcreated_by(int value)
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
	private String privatedone_at;
	public final String getdone_at()
	{
		return privatedone_at;
	}
	public final void setdone_at(String value)
	{
		privatedone_at = value;
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
}