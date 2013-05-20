Imports System.Collections.Generic
Imports System.Text

Namespace GeopalJobSample

	Public Class GeopalRequest
		Public Property status() As [String]
			Get
				Return m_status
			End Get
			Set
				m_status = Value
			End Set
		End Property
		Private m_status As [String]
		Public Property company() As Company
			Get
				Return m_company
			End Get
			Set
				m_company = Value
			End Set
		End Property
		Private m_company As Company
	End Class

	Public Class GeopalRequestJobIds
		Inherits GeopalRequest
		Public Property jobs() As IEnumerable(Of JobJustId)
			Get
				Return m_jobs
			End Get
			Set
				m_jobs = Value
			End Set
		End Property
		Private m_jobs As IEnumerable(Of JobJustId)
	End Class


	Public Class GeopalRequestJob
		Inherits GeopalRequest
		Public Property job() As Job
			Get
				Return m_job
			End Get
			Set
				m_job = Value
			End Set
		End Property
		Private m_job As Job
	End Class

	Public Class GeopalRequestJobTemplates
		Inherits GeopalRequest
		Public Property job_templates() As IEnumerable(Of JobTemplateSimple)
			Get
				Return m_job_templates
			End Get
			Set
				m_job_templates = Value
			End Set
		End Property
		Private m_job_templates As IEnumerable(Of JobTemplateSimple)
	End Class

	Public Class GeopalRequestJobTemplate
		Inherits GeopalRequest
		Public Property job_template() As JobTemplate
			Get
				Return m_job_template
			End Get
			Set
				m_job_template = Value
			End Set
		End Property
		Private m_job_template As JobTemplate
	End Class

	Public Class GeopalRequestEmployees
		Inherits GeopalRequest
		Public Property employees() As IEnumerable(Of Employee)
			Get
				Return m_employees
			End Get
			Set
				m_employees = Value
			End Set
		End Property
		Private m_employees As IEnumerable(Of Employee)
	End Class


	Public Class Company
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
		Public Property name() As [String]
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As [String]
	End Class

	Public Class Person
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
		Public Property identifier() As [String]
			Get
				Return m_identifier
			End Get
			Set
				m_identifier = Value
			End Set
		End Property
		Private m_identifier As [String]
		Public Property title() As [String]
			Get
				Return m_title
			End Get
			Set
				m_title = Value
			End Set
		End Property
		Private m_title As [String]
		Public Property first_name() As [String]
			Get
				Return m_first_name
			End Get
			Set
				m_first_name = Value
			End Set
		End Property
		Private m_first_name As [String]
		Public Property last_name() As [String]
			Get
				Return m_last_name
			End Get
			Set
				m_last_name = Value
			End Set
		End Property
		Private m_last_name As [String]
		Public Property mobile_number() As [String]
			Get
				Return m_mobile_number
			End Get
			Set
				m_mobile_number = Value
			End Set
		End Property
		Private m_mobile_number As [String]
		Public Property phone_number() As [String]
			Get
				Return m_phone_number
			End Get
			Set
				m_phone_number = Value
			End Set
		End Property
		Private m_phone_number As [String]
		Public Property phone_number_alternate() As [String]
			Get
				Return m_phone_number_alternate
			End Get
			Set
				m_phone_number_alternate = Value
			End Set
		End Property
		Private m_phone_number_alternate As [String]
		Public Property fax_number() As [String]
			Get
				Return m_fax_number
			End Get
			Set
				m_fax_number = Value
			End Set
		End Property
		Private m_fax_number As [String]
		Public Property email() As [String]
			Get
				Return m_email
			End Get
			Set
				m_email = Value
			End Set
		End Property
		Private m_email As [String]
		Public Property updated_on() As [String]
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As [String]
	End Class

	Public Class Address
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
		Public Property identifier() As [String]
			Get
				Return m_identifier
			End Get
			Set
				m_identifier = Value
			End Set
		End Property
		Private m_identifier As [String]
		Public Property address_line_1() As [String]
			Get
				Return m_address_line_1
			End Get
			Set
				m_address_line_1 = Value
			End Set
		End Property
		Private m_address_line_1 As [String]
		Public Property address_line_2() As [String]
			Get
				Return m_address_line_2
			End Get
			Set
				m_address_line_2 = Value
			End Set
		End Property
		Private m_address_line_2 As [String]
		Public Property address_line_3() As [String]
			Get
				Return m_address_line_3
			End Get
			Set
				m_address_line_3 = Value
			End Set
		End Property
		Private m_address_line_3 As [String]
		Public Property city() As [String]
			Get
				Return m_city
			End Get
			Set
				m_city = Value
			End Set
		End Property
		Private m_city As [String]
		Public Property postal_code() As [String]
			Get
				Return m_postal_code
			End Get
			Set
				m_postal_code = Value
			End Set
		End Property
		Private m_postal_code As [String]
		Public Property country_id() As [String]
			Get
				Return m_country_id
			End Get
			Set
				m_country_id = Value
			End Set
		End Property
		Private m_country_id As [String]
		Public Property lat() As [String]
			Get
				Return m_lat
			End Get
			Set
				m_lat = Value
			End Set
		End Property
		Private m_lat As [String]
		Public Property lng() As [String]
			Get
				Return m_lng
			End Get
			Set
				m_lng = Value
			End Set
		End Property
		Private m_lng As [String]
		Public Property coordinates_verified() As [String]
			Get
				Return m_coordinates_verified
			End Get
			Set
				m_coordinates_verified = Value
			End Set
		End Property
		Private m_coordinates_verified As [String]
		Public Property updated_on() As [String]
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As [String]
	End Class

	Public Class Customer
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
		Public Property identifier() As [String]
			Get
				Return m_identifier
			End Get
			Set
				m_identifier = Value
			End Set
		End Property
		Private m_identifier As [String]
		Public Property name() As [String]
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As [String]
		Public Property updated_on() As [String]
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As [String]
	End Class

	Public Class JobTemplate
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
		Public Property name() As [String]
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As [String]
		Public Property estimate_job_duration() As [String]
			Get
				Return m_estimate_job_duration
			End Get
			Set
				m_estimate_job_duration = Value
			End Set
		End Property
		Private m_estimate_job_duration As [String]
		Public Property default_rate_per_hour() As [String]
			Get
				Return m_default_rate_per_hour
			End Get
			Set
				m_default_rate_per_hour = Value
			End Set
		End Property
		Private m_default_rate_per_hour As [String]
		Public Property priority_list() As [String]
			Get
				Return m_priority_list
			End Get
			Set
				m_priority_list = Value
			End Set
		End Property
		Private m_priority_list As [String]
		Public Property description() As [String]
			Get
				Return m_description
			End Get
			Set
				m_description = Value
			End Set
		End Property
		Private m_description As [String]
		Public Property company_id() As [String]
			Get
				Return m_company_id
			End Get
			Set
				m_company_id = Value
			End Set
		End Property
		Private m_company_id As [String]
		Public Property review_job() As [String]
			Get
				Return m_review_job
			End Get
			Set
				m_review_job = Value
			End Set
		End Property
		Private m_review_job As [String]
		Public Property is_deleted() As [String]
			Get
				Return m_is_deleted
			End Get
			Set
				m_is_deleted = Value
			End Set
		End Property
		Private m_is_deleted As [String]
		Public Property updated_by() As [String]
			Get
				Return m_updated_by
			End Get
			Set
				m_updated_by = Value
			End Set
		End Property
		Private m_updated_by As [String]
		Public Property updated_on() As [String]
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As [String]
		Public Property created_by() As [String]
			Get
				Return m_created_by
			End Get
			Set
				m_created_by = Value
			End Set
		End Property
		Private m_created_by As [String]
		Public Property created_on() As [String]
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As [String]
		Public Property job_template_fields() As List(Of JobTemplateField)
			Get
				Return m_job_template_fields
			End Get
			Set
				m_job_template_fields = Value
			End Set
		End Property
		Private m_job_template_fields As List(Of JobTemplateField)
		Public Property job_template_workflows() As List(Of JobTemplateWorkflow)
			Get
				Return m_job_template_workflows
			End Get
			Set
				m_job_template_workflows = Value
			End Set
		End Property
		Private m_job_template_workflows As List(Of JobTemplateWorkflow)
	End Class

	Public Class JobTemplateSimple
		Public Property job_template_id() As [String]
			Get
				Return m_job_template_id
			End Get
			Set
				m_job_template_id = Value
			End Set
		End Property
		Private m_job_template_id As [String]
		Public Property name() As [String]
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As [String]
		Public Property is_deleted() As Boolean
			Get
				Return m_is_deleted
			End Get
			Set
				m_is_deleted = Value
			End Set
		End Property
		Private m_is_deleted As Boolean
		Public Property updated_on() As [String]
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As [String]
	End Class


	Public Class Employee
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property title() As String
			Get
				Return m_title
			End Get
			Set
				m_title = Value
			End Set
		End Property
		Private m_title As String
		Public Property first_name() As String
			Get
				Return m_first_name
			End Get
			Set
				m_first_name = Value
			End Set
		End Property
		Private m_first_name As String
		Public Property last_name() As String
			Get
				Return m_last_name
			End Get
			Set
				m_last_name = Value
			End Set
		End Property
		Private m_last_name As String
		Public Property mobile_number() As String
			Get
				Return m_mobile_number
			End Get
			Set
				m_mobile_number = Value
			End Set
		End Property
		Private m_mobile_number As String
		Public Property lat() As String
			Get
				Return m_lat
			End Get
			Set
				m_lat = Value
			End Set
		End Property
		Private m_lat As String
		Public Property lng() As String
			Get
				Return m_lng
			End Get
			Set
				m_lng = Value
			End Set
		End Property
		Private m_lng As String
		Public Property address() As String
			Get
				Return m_address
			End Get
			Set
				m_address = Value
			End Set
		End Property
		Private m_address As String
		Public Property last_updated_on() As String
			Get
				Return m_last_updated_on
			End Get
			Set
				m_last_updated_on = Value
			End Set
		End Property
		Private m_last_updated_on As String
	End Class


	Public Class JobJustId
		Public Property id() As [String]
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As [String]
	End Class


	Public Class CreatedBy
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property title() As String
			Get
				Return m_title
			End Get
			Set
				m_title = Value
			End Set
		End Property
		Private m_title As String
		Public Property first_name() As String
			Get
				Return m_first_name
			End Get
			Set
				m_first_name = Value
			End Set
		End Property
		Private m_first_name As String
		Public Property last_name() As String
			Get
				Return m_last_name
			End Get
			Set
				m_last_name = Value
			End Set
		End Property
		Private m_last_name As String
	End Class

	Public Class JobWorkflow
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property job_id() As Integer
			Get
				Return m_job_id
			End Get
			Set
				m_job_id = Value
			End Set
		End Property
		Private m_job_id As Integer
		Public Property employee_id() As Object
			Get
				Return m_employee_id
			End Get
			Set
				m_employee_id = Value
			End Set
		End Property
		Private m_employee_id As Object
		Public Property template_workflow_id() As Integer
			Get
				Return m_template_workflow_id
			End Get
			Set
				m_template_workflow_id = Value
			End Set
		End Property
		Private m_template_workflow_id As Integer
		Public Property name() As String
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As String
		Public Property action() As String
			Get
				Return m_action
			End Get
			Set
				m_action = Value
			End Set
		End Property
		Private m_action As String
		Public Property [optional]() As Integer
			Get
				Return m_optional
			End Get
			Set
				m_optional = Value
			End Set
		End Property
		Private m_optional As Integer
		Public Property action_values() As String
			Get
				Return m_action_values
			End Get
			Set
				m_action_values = Value
			End Set
		End Property
		Private m_action_values As String
		Public Property action_value_entered() As String
			Get
				Return m_action_value_entered
			End Get
			Set
				m_action_value_entered = Value
			End Set
		End Property
		Private m_action_value_entered As String
		Public Property nested_workflow_id() As Integer
			Get
				Return m_nested_workflow_id
			End Get
			Set
				m_nested_workflow_id = Value
			End Set
		End Property
		Private m_nested_workflow_id As Integer
		Public Property lat() As System.Nullable(Of Integer)
			Get
				Return m_lat
			End Get
			Set
				m_lat = Value
			End Set
		End Property
		Private m_lat As System.Nullable(Of Integer)
		Public Property lng() As System.Nullable(Of Integer)
			Get
				Return m_lng
			End Get
			Set
				m_lng = Value
			End Set
		End Property
		Private m_lng As System.Nullable(Of Integer)
		Public Property done_at() As String
			Get
				Return m_done_at
			End Get
			Set
				m_done_at = Value
			End Set
		End Property
		Private m_done_at As String
		Public Property done_by() As String
			Get
				Return m_done_by
			End Get
			Set
				m_done_by = Value
			End Set
		End Property
		Private m_done_by As String
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
		Public Property done() As Boolean
			Get
				Return m_done
			End Get
			Set
				m_done = Value
			End Set
		End Property
		Private m_done As Boolean
		Public Property job_workflow_files() As List(Of JobWorkflowFile)
			Get
				Return m_job_workflow_files
			End Get
			Set
				m_job_workflow_files = Value
			End Set
		End Property
		Private m_job_workflow_files As List(Of JobWorkflowFile)
	End Class

	Public Class JobField
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property job_id() As Integer
			Get
				Return m_job_id
			End Get
			Set
				m_job_id = Value
			End Set
		End Property
		Private m_job_id As Integer
		Public Property template_field_id() As Integer
			Get
				Return m_template_field_id
			End Get
			Set
				m_template_field_id = Value
			End Set
		End Property
		Private m_template_field_id As Integer
		Public Property name() As String
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As String
		Public Property action() As String
			Get
				Return m_action
			End Get
			Set
				m_action = Value
			End Set
		End Property
		Private m_action As String
		Public Property action_values() As String
			Get
				Return m_action_values
			End Get
			Set
				m_action_values = Value
			End Set
		End Property
		Private m_action_values As String
		Public Property action_value_entered() As String
			Get
				Return m_action_value_entered
			End Get
			Set
				m_action_value_entered = Value
			End Set
		End Property
		Private m_action_value_entered As String
		Public Property done_at() As String
			Get
				Return m_done_at
			End Get
			Set
				m_done_at = Value
			End Set
		End Property
		Private m_done_at As String
		Public Property done_by() As String
			Get
				Return m_done_by
			End Get
			Set
				m_done_by = Value
			End Set
		End Property
		Private m_done_by As String
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
	End Class

	Public Class JobWorkflowFile
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property job_id() As Integer
			Get
				Return m_job_id
			End Get
			Set
				m_job_id = Value
			End Set
		End Property
		Private m_job_id As Integer
		Public Property job_workflow_id() As Integer
			Get
				Return m_job_workflow_id
			End Get
			Set
				m_job_workflow_id = Value
			End Set
		End Property
		Private m_job_workflow_id As Integer
		Public Property s3file_id() As Integer
			Get
				Return m_s3file_id
			End Get
			Set
				m_s3file_id = Value
			End Set
		End Property
		Private m_s3file_id As Integer
		Public Property s3file_thumbnail_id() As Integer
			Get
				Return m_s3file_thumbnail_id
			End Get
			Set
				m_s3file_thumbnail_id = Value
			End Set
		End Property
		Private m_s3file_thumbnail_id As Integer
		Public Property file_name() As String
			Get
				Return m_file_name
			End Get
			Set
				m_file_name = Value
			End Set
		End Property
		Private m_file_name As String
		Public Property file_mime_type() As String
			Get
				Return m_file_mime_type
			End Get
			Set
				m_file_mime_type = Value
			End Set
		End Property
		Private m_file_mime_type As String
		Public Property link_2_file() As String
			Get
				Return m_link_2_file
			End Get
			Set
				m_link_2_file = Value
			End Set
		End Property
		Private m_link_2_file As String
		Public Property link_2_file_thumbnail() As String
			Get
				Return m_link_2_file_thumbnail
			End Get
			Set
				m_link_2_file_thumbnail = Value
			End Set
		End Property
		Private m_link_2_file_thumbnail As String
		Public Property uploaded_from() As String
			Get
				Return m_uploaded_from
			End Get
			Set
				m_uploaded_from = Value
			End Set
		End Property
		Private m_uploaded_from As String
		Public Property done_by() As Integer
			Get
				Return m_done_by
			End Get
			Set
				m_done_by = Value
			End Set
		End Property
		Private m_done_by As Integer
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_on() As Object
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As Object
	End Class

	Public Class JobStatusChangeMessage
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property job_id() As Integer
			Get
				Return m_job_id
			End Get
			Set
				m_job_id = Value
			End Set
		End Property
		Private m_job_id As Integer
		Public Property job_status_id() As Integer
			Get
				Return m_job_status_id
			End Get
			Set
				m_job_status_id = Value
			End Set
		End Property
		Private m_job_status_id As Integer
		Public Property message() As String
			Get
				Return m_message
			End Get
			Set
				m_message = Value
			End Set
		End Property
		Private m_message As String
		Public Property company_id() As Integer
			Get
				Return m_company_id
			End Get
			Set
				m_company_id = Value
			End Set
		End Property
		Private m_company_id As Integer
		Public Property created_by() As Integer
			Get
				Return m_created_by
			End Get
			Set
				m_created_by = Value
			End Set
		End Property
		Private m_created_by As Integer
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property done_at() As String
			Get
				Return m_done_at
			End Get
			Set
				m_done_at = Value
			End Set
		End Property
		Private m_done_at As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
	End Class

	Public Class Job
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property schedule_log_id() As String
			Get
				Return m_schedule_log_id
			End Get
			Set
				m_schedule_log_id = Value
			End Set
		End Property
		Private m_schedule_log_id As String
		Public Property schedule_job_status_id() As String
			Get
				Return m_schedule_job_status_id
			End Get
			Set
				m_schedule_job_status_id = Value
			End Set
		End Property
		Private m_schedule_job_status_id As String
		Public Property identifier() As String
			Get
				Return m_identifier
			End Get
			Set
				m_identifier = Value
			End Set
		End Property
		Private m_identifier As String
		Public Property estimated_duration() As Integer
			Get
				Return m_estimated_duration
			End Get
			Set
				m_estimated_duration = Value
			End Set
		End Property
		Private m_estimated_duration As Integer
		Public Property rate_per_hour() As Integer
			Get
				Return m_rate_per_hour
			End Get
			Set
				m_rate_per_hour = Value
			End Set
		End Property
		Private m_rate_per_hour As Integer
		Public Property job_status_id() As Integer
			Get
				Return m_job_status_id
			End Get
			Set
				m_job_status_id = Value
			End Set
		End Property
		Private m_job_status_id As Integer
		Public Property start_date() As String
			Get
				Return m_start_date
			End Get
			Set
				m_start_date = Value
			End Set
		End Property
		Private m_start_date As String
		Public Property start_time() As String
			Get
				Return m_start_time
			End Get
			Set
				m_start_time = Value
			End Set
		End Property
		Private m_start_time As String
		Public Property start_date_time() As String
			Get
				Return m_start_date_time
			End Get
			Set
				m_start_date_time = Value
			End Set
		End Property
		Private m_start_date_time As String
		Public Property prefered_start_date_time() As String
			Get
				Return m_prefered_start_date_time
			End Get
			Set
				m_prefered_start_date_time = Value
			End Set
		End Property
		Private m_prefered_start_date_time As String
		Public Property prefered_stop_date_time() As String
			Get
				Return m_prefered_stop_date_time
			End Get
			Set
				m_prefered_stop_date_time = Value
			End Set
		End Property
		Private m_prefered_stop_date_time As String
		Public Property duration() As String
			Get
				Return m_duration
			End Get
			Set
				m_duration = Value
			End Set
		End Property
		Private m_duration As String
		Public Property priority_text() As String
			Get
				Return m_priority_text
			End Get
			Set
				m_priority_text = Value
			End Set
		End Property
		Private m_priority_text As String
		Public Property priority_color() As String
			Get
				Return m_priority_color
			End Get
			Set
				m_priority_color = Value
			End Set
		End Property
		Private m_priority_color As String
		Public Property company() As Company
			Get
				Return m_company
			End Get
			Set
				m_company = Value
			End Set
		End Property
		Private m_company As Company
		Public Property person() As Person
			Get
				Return m_person
			End Get
			Set
				m_person = Value
			End Set
		End Property
		Private m_person As Person
		Public Property address() As Address
			Get
				Return m_address
			End Get
			Set
				m_address = Value
			End Set
		End Property
		Private m_address As Address
		Public Property customer() As Customer
			Get
				Return m_customer
			End Get
			Set
				m_customer = Value
			End Set
		End Property
		Private m_customer As Customer
		Public Property job_template() As JobTemplate
			Get
				Return m_job_template
			End Get
			Set
				m_job_template = Value
			End Set
		End Property
		Private m_job_template As JobTemplate
		Public Property notes() As String
			Get
				Return m_notes
			End Get
			Set
				m_notes = Value
			End Set
		End Property
		Private m_notes As String
		Public Property employee() As Employee
			Get
				Return m_employee
			End Get
			Set
				m_employee = Value
			End Set
		End Property
		Private m_employee As Employee
		Public Property created_by() As CreatedBy
			Get
				Return m_created_by
			End Get
			Set
				m_created_by = Value
			End Set
		End Property
		Private m_created_by As CreatedBy
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
		Public Property assigned_at() As String
			Get
				Return m_assigned_at
			End Get
			Set
				m_assigned_at = Value
			End Set
		End Property
		Private m_assigned_at As String
		Public Property end_time() As String
			Get
				Return m_end_time
			End Get
			Set
				m_end_time = Value
			End Set
		End Property
		Private m_end_time As String
		Public Property job_workflows() As List(Of JobWorkflow)
			Get
				Return m_job_workflows
			End Get
			Set
				m_job_workflows = Value
			End Set
		End Property
		Private m_job_workflows As List(Of JobWorkflow)
		Public Property job_fields() As List(Of JobField)
			Get
				Return m_job_fields
			End Get
			Set
				m_job_fields = Value
			End Set
		End Property
		Private m_job_fields As List(Of JobField)
		Public Property job_workflow_files() As List(Of JobWorkflowFile)
			Get
				Return m_job_workflow_files
			End Get
			Set
				m_job_workflow_files = Value
			End Set
		End Property
		Private m_job_workflow_files As List(Of JobWorkflowFile)
		Public Property job_field_files() As List(Of Object)
			Get
				Return m_job_field_files
			End Get
			Set
				m_job_field_files = Value
			End Set
		End Property
		Private m_job_field_files As List(Of Object)
		Public Property job_assigned_to() As String
			Get
				Return m_job_assigned_to
			End Get
			Set
				m_job_assigned_to = Value
			End Set
		End Property
		Private m_job_assigned_to As String
		Public Property job_status_change_messages() As List(Of JobStatusChangeMessage)
			Get
				Return m_job_status_change_messages
			End Get
			Set
				m_job_status_change_messages = Value
			End Set
		End Property
		Private m_job_status_change_messages As List(Of JobStatusChangeMessage)
	End Class

	Public Class JobTemplateField
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property template_id() As String
			Get
				Return m_template_id
			End Get
			Set
				m_template_id = Value
			End Set
		End Property
		Private m_template_id As String
		Public Property name() As String
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As String
		Public Property action() As String
			Get
				Return m_action
			End Get
			Set
				m_action = Value
			End Set
		End Property
		Private m_action As String
		Public Property action_values() As String
			Get
				Return m_action_values
			End Get
			Set
				m_action_values = Value
			End Set
		End Property
		Private m_action_values As String
		Public Property include_in_reports() As String
			Get
				Return m_include_in_reports
			End Get
			Set
				m_include_in_reports = Value
			End Set
		End Property
		Private m_include_in_reports As String
		Public Property order_number() As String
			Get
				Return m_order_number
			End Get
			Set
				m_order_number = Value
			End Set
		End Property
		Private m_order_number As String
		Public Property is_deleted() As String
			Get
				Return m_is_deleted
			End Get
			Set
				m_is_deleted = Value
			End Set
		End Property
		Private m_is_deleted As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_at() As String
			Get
				Return m_updated_at
			End Get
			Set
				m_updated_at = Value
			End Set
		End Property
		Private m_updated_at As String
	End Class

	Public Class JobTemplateWorkflow
		Public Property id() As Integer
			Get
				Return m_id
			End Get
			Set
				m_id = Value
			End Set
		End Property
		Private m_id As Integer
		Public Property template_id() As String
			Get
				Return m_template_id
			End Get
			Set
				m_template_id = Value
			End Set
		End Property
		Private m_template_id As String
		Public Property name() As String
			Get
				Return m_name
			End Get
			Set
				m_name = Value
			End Set
		End Property
		Private m_name As String
		Public Property action() As String
			Get
				Return m_action
			End Get
			Set
				m_action = Value
			End Set
		End Property
		Private m_action As String
		Public Property [optional]() As String
			Get
				Return m_optional
			End Get
			Set
				m_optional = Value
			End Set
		End Property
		Private m_optional As String
		Public Property action_value_entered() As String
			Get
				Return m_action_value_entered
			End Get
			Set
				m_action_value_entered = Value
			End Set
		End Property
		Private m_action_value_entered As String
		Public Property nested_workflow_id() As String
			Get
				Return m_nested_workflow_id
			End Get
			Set
				m_nested_workflow_id = Value
			End Set
		End Property
		Private m_nested_workflow_id As String
		Public Property include_in_reports() As String
			Get
				Return m_include_in_reports
			End Get
			Set
				m_include_in_reports = Value
			End Set
		End Property
		Private m_include_in_reports As String
		Public Property level_number() As String
			Get
				Return m_level_number
			End Get
			Set
				m_level_number = Value
			End Set
		End Property
		Private m_level_number As String
		Public Property order_number() As String
			Get
				Return m_order_number
			End Get
			Set
				m_order_number = Value
			End Set
		End Property
		Private m_order_number As String
		Public Property is_deleted() As String
			Get
				Return m_is_deleted
			End Get
			Set
				m_is_deleted = Value
			End Set
		End Property
		Private m_is_deleted As String
		Public Property updated_on() As String
			Get
				Return m_updated_on
			End Get
			Set
				m_updated_on = Value
			End Set
		End Property
		Private m_updated_on As String
		Public Property created_on() As String
			Get
				Return m_created_on
			End Get
			Set
				m_created_on = Value
			End Set
		End Property
		Private m_created_on As String
		Public Property updated_at() As String
			Get
				Return m_updated_at
			End Get
			Set
				m_updated_at = Value
			End Set
		End Property
		Private m_updated_at As String
	End Class
End Namespace