package GeopalJobSample;

public class GeopalRequestEmployees extends GeopalRequest
{
	private Iterable<Employee> privateemployees;
	public final Iterable<Employee> getemployees()
	{
		return privateemployees;
	}
	public final void setemployees(Iterable<Employee> value)
	{
		privateemployees = value;
	}
}