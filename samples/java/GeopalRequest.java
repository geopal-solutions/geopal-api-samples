package GeopalJobSample;

public class GeopalRequest
{
	private String privatestatus;
	public final String getstatus()
	{
		return privatestatus;
	}
	public final void setstatus(String value)
	{
		privatestatus = value;
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
}