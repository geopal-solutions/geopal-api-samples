package GeopalJobSample;

public class GeopalRequestJobTemplates extends GeopalRequest
{
	private Iterable<JobTemplateSimple> privatejob_templates;
	public final Iterable<JobTemplateSimple> getjob_templates()
	{
		return privatejob_templates;
	}
	public final void setjob_templates(Iterable<JobTemplateSimple> value)
	{
		privatejob_templates = value;
	}
}