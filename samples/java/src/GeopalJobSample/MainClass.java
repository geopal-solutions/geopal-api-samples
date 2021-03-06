
package GeopalJobSample;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;

import com.edm.geopal.json.JSONObjectWrapper;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class MainClass
{
    private static String employeeId = "";
    private static String privateKey = "";

    public static void main(String args[]) throws GeopalClientException, IOException {

        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));

        System.out.println("Geopal Sample");
        System.out.println("Please Enter Employee ID:");

        employeeId = bufferRead.readLine();

        System.out.println("Please Enter Private Key:");
        privateKey = bufferRead.readLine();

        int choice = 0;
        while (choice != -1) {
            System.out.println("");
            System.out.println("");
            System.out.println("");
            System.out.println("---------------------------------------------------------");
            System.out.println("Create A Job: 1");
            System.out.println("Read A Job: 2");
            System.out.println("List All Job Templates: 3");
            System.out.println("Read Job Template: 4");
            System.out.println("Read Jobs Between Date Rage: 5");
            System.out.println("List Employees: 6");
            System.out.println("Please Choose");

            try {
                choice = Integer.valueOf(bufferRead.readLine());
            } catch (IOException e) {
                choice = 0;
            }

            switch (choice) {
                case 1:
                    createAJob();
                    break;
                case 2:
                    readAJob();
                    break;
                case 3:
                    listTemplates();
                    break;
                case 4:
                    readTemplate();
                    break;
                case 5:
                    readJobsDateRange();
                    break;
                case 6:
                    listEmployess();
                    break;
                default:
                    System.out.println("Invalid Choice");
                    break;
            }
        }

    }

    /**
     * creates a job
     * 
     * @throws IOException
     * @throws JSONException
     * @throws GeopalClientException
     */
    private static void createAJob() throws IOException, JSONException, GeopalClientException
    {
        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Please enter a job template id");
        String jobTemplateId = bufferRead.readLine();
        GeopalClient geopalClient = new GeopalClient("api/jobs/createandassign");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);

        List<NameValuePair> pairs = new ArrayList<NameValuePair>();
        pairs.add(new BasicNameValuePair("template_id", jobTemplateId));

        JSONObjectWrapper response = new JSONObjectWrapper(geopalClient.post(pairs).toJSON()
                .getJSONObject("job"));

        System.out.println("Created Job With Identifier = " + response.getString("identifier"));
        System.out.println("Created Job With Id = " + response.getInt("id"));
    }

    /**
     * reads a new job
     * 
     * @throws IOException
     * @throws JSONException
     * @throws GeopalClientException
     */
    private static void readAJob() throws IOException, JSONException, GeopalClientException
    {
        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Please enter a job id");
        String jobId = bufferRead.readLine();
        readAJob(jobId);
    }
    
    private static void readAJob(int jobId) throws JSONException, GeopalClientException {
        readAJob(String.valueOf(jobId));
    }

    /**
     * reads in an existing job
     * 
     * @param jobId
     * @throws JSONException
     * @throws GeopalClientException
     */
    private static void readAJob(String jobId) throws JSONException, GeopalClientException
    {
        GeopalClient geopalClient = new GeopalClient("api/jobs/get");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);

        List<NameValuePair> pairs = new ArrayList<NameValuePair>();
        pairs.add(new BasicNameValuePair("job_id", jobId));

        JSONObjectWrapper response = new JSONObjectWrapper(geopalClient.get(pairs).toJSON()
                .getJSONObject("job"));
        System.out.println("Job Identifier: " + response.getString("identifier"));
        System.out.println("Job Template: "
                + response.getJSONObject("job_template").getString("name"));

        System.out.println("Job Fields");

        for (int i = 0; i < response.getJSONArray("job_fields").length(); i++) {
            JSONObjectWrapper fieldJsonObject = new JSONObjectWrapper(response
                    .getJSONArray("job_fields").getJSONObject(i));
            System.out.println(fieldJsonObject.getString("name", "") + " ("
                    + fieldJsonObject.getInt("id") + ") "
                    + fieldJsonObject.getString("action_value_entered"));
        }

        for (int i = 0; i < response.getJSONArray("job_workflows").length(); i++) {
            JSONObjectWrapper workflowJsonObject = new JSONObjectWrapper(response
                    .getJSONArray("job_workflows").getJSONObject(i));
            System.out.println(workflowJsonObject.getString("name", "") + " ("
                    + workflowJsonObject.getInt("id") + ") "
                    + workflowJsonObject.getString("action_value_entered"));
        }

    }

    /**
     * reads in a new job template
     * 
     * @throws GeopalClientException
     * @throws IOException
     */
    private static void readTemplate() throws GeopalClientException, IOException
    {
        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Please enter a job template id");
        String jobTemplateId = bufferRead.readLine();
        GeopalClient geopalClient = new GeopalClient("api/jobtemplates/get");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);

        List<NameValuePair> pairs = new ArrayList<NameValuePair>();
        pairs.add(new BasicNameValuePair("template_id", jobTemplateId));

        JSONObjectWrapper response = new JSONObjectWrapper(geopalClient.get(pairs)
                .toJSON().getJSONObject("job_template"));

        System.out.println("Job Template Name = " + response.getString("name"));
        System.out.println("Job Fields");

        for (int i = 0; i < response.getJSONArray("job_template_fields").length(); i++) {
            JSONObjectWrapper fieldJsonObject = new JSONObjectWrapper(response
                    .getJSONArray("job_template_fields").getJSONObject(i));
            System.out.println(fieldJsonObject.getString("name", "") + " ("
                    + fieldJsonObject.getInt("id") + ")");
        }

        for (int i = 0; i < response.getJSONArray("job_template_workflows")
                .length(); i++) {
            JSONObjectWrapper workflowJsonObject = new JSONObjectWrapper(response
                    .getJSONArray("job_template_workflows").getJSONObject(i));
            System.out.println(workflowJsonObject.getString("name", "") + " ("
                    + workflowJsonObject.getInt("id") + ") ["
                    + workflowJsonObject.getString("action") + "]");
        }

    }

    /**
     * reads in all job templates
     * 
     */
    private static void listTemplates()
    {
        GeopalClient geopalClient = new GeopalClient("api/jobtemplates/all");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);
        JSONObjectWrapper jsonObject;
        try {
            jsonObject = geopalClient.get().toJSON();
            JSONArray response = jsonObject.getJSONArray("job_templates");

            for (int i = 0; i < response.length(); i++) {
                JSONObjectWrapper templateJsonObject = new JSONObjectWrapper(
                        response.getJSONObject(i));
                System.out.println(templateJsonObject.getString("name", "") + " ("
                        + templateJsonObject.getInt("job_template_id") + ")");
            }
        } catch (GeopalClientException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

    }

    /**
     * reads in jobs via date range
     * 
     * @throws JSONException
     * @throws GeopalClientException
     * @throws IOException
     */
    private static void readJobsDateRange() throws JSONException, GeopalClientException,
            IOException
    {
        System.out
                .println("Please enter a from date (yyyy-MM-dd HH:mm:ss) see http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx");

        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));

        String dateTimeFrom = bufferRead.readLine();

        System.out.println("Please enter a to date (yyyy-MM-dd HH:mm:ss)");
        String dateTimeTo = bufferRead.readLine();

        List<NameValuePair> pairs = new ArrayList<NameValuePair>();
        pairs.add(new BasicNameValuePair("date_time_from", dateTimeFrom));
        pairs.add(new BasicNameValuePair("date_time_to", dateTimeTo));

        GeopalClient geopalClient = new GeopalClient("api/jobsearch/ids");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);
        JSONArray response = geopalClient.get(pairs).toJSON().getJSONArray("jobs");
        for (int i = 0; i < response.length(); i++) {
            JSONObjectWrapper jobJsonObject = new JSONObjectWrapper(
                    response.getJSONObject(i));
            System.out.println(jobJsonObject.getInt("id"));
            readAJob(jobJsonObject.getInt("id"));
        }
    }

    

    /**
     * lists all employees
     * 
     * @throws JSONException
     * @throws GeopalClientException
     */
    private static void listEmployess() throws JSONException, GeopalClientException
    {
        GeopalClient geopalClient = new GeopalClient("api/employees/all");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);
        JSONArray response = geopalClient.get().toJSON().getJSONArray("employees");
        for (int i = 0; i < response.length(); i++) {
            JSONObjectWrapper employeeJsonObject = new JSONObjectWrapper(
                    response.getJSONObject(i));
            System.out.println(employeeJsonObject.getString("first_name", "") + " "
                    + employeeJsonObject.getString("last_name") + " ("
                    + employeeJsonObject.getInt("id") + ") "
                    + employeeJsonObject.getString("address", ""));
        }

    }
}
