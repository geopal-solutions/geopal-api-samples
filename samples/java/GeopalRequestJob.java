package GeopalJobSample;

public class GeopalRequestJob extends GeopalRequest
{
	private Job privatejob;
	public final Job getjob()
	{
		return privatejob;
	}
	public final void setjob(Job value)
	{
		privatejob = value;
	}
}