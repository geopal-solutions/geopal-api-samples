package GeopalJobSample;

public class GeopalRequestJobIds extends GeopalRequest
{
	private Iterable<JobJustId> privatejobs;
	public final Iterable<JobJustId> getjobs()
	{
		return privatejobs;
	}
	public final void setjobs(Iterable<JobJustId> value)
	{
		privatejobs = value;
	}
}