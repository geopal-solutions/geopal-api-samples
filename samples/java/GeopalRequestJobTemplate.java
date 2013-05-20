package GeopalJobSample;

public class GeopalRequestJobTemplate extends GeopalRequest
{
	private JobTemplate privatejob_template;
	public final JobTemplate getjob_template()
	{
		return privatejob_template;
	}
	public final void setjob_template(JobTemplate value)
	{
		privatejob_template = value;
	}
}