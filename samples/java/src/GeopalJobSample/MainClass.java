
package GeopalJobSample;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
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
        try {
            employeeId = bufferRead.readLine();
        } catch (IOException e2) {
          //error
        }

        System.out.println("Please Enter Private Key:");
        try {
            privateKey = bufferRead.readLine();
        } catch (IOException e1) {
            //error
        }

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

            System.out.println(choice);
            switch (choice) {
                case 1:
                    // createAJob ();
                    break;
                case 2:
                    // readAJob ();
                    break;
                case 3:
                    listTemplates ();
                    break;
                case 4:
                    readTemplate();
                    break;
                case 5:
                    // readJobsDateRange ();
                    break;
                case 6:
                    // listEmployess();
                    break;
                default:
                    System.out.println("Invalid Choice");
                    break;
            }
        }
        
        
        

    }
    
    private static void readTemplate () throws GeopalClientException, IOException
    {
        BufferedReader bufferRead = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Please enter a job template id");
        String jobTemplateId = bufferRead.readLine();
        GeopalClient geopalClient = new GeopalClient("api/jobtemplates/get");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);
        
        List<NameValuePair> pairs = new ArrayList<NameValuePair>();
        pairs.add(new BasicNameValuePair("template_id", jobTemplateId));
 
         JSONObjectWrapper geopalRequestJobTemplate = geopalClient.get(pairs).toJSON();
        
         System.out.println("Job Template Name = " + geopalRequestJobTemplate.getString("name"));
        System.out.println("Job Fields");
        
        for (int i = 0; i < geopalRequestJobTemplate.getJSONArray("job_template_fields").length(); i++) {
            JSONObjectWrapper jsonObjectTemplate = new JSONObjectWrapper(geopalRequestJobTemplate.getJSONArray("job_template_fields").getJSONObject(i));
            System.out.println(jsonObjectTemplate.getString("name", "") + " (" + jsonObjectTemplate.getInt("id") + ")");
          }
        
        
        for (int i = 0; i < geopalRequestJobTemplate.getJSONArray("job_template_workflows").length(); i++) {
            JSONObjectWrapper jsonObjectTemplate = new JSONObjectWrapper(geopalRequestJobTemplate.getJSONArray("job_template_fields").getJSONObject(i));
            System.out.println(jsonObjectTemplate.getString("name", "") + " (" + jsonObjectTemplate.getInt("id") + ") ["+jsonObjectTemplate.getString("action")+"]");
          }
        

    }
    
   
    private static void listTemplates()
    {
        GeopalClient geopalClient = new GeopalClient("api/jobtemplates/all");
        geopalClient.setEmployeeId(employeeId);
        geopalClient.setPrivateKey(privateKey);
        JSONObjectWrapper jsonObject;
        try {
            jsonObject = geopalClient.get().toJSON();
            JSONArray jsonArrayTemplates = jsonObject.getJSONArray("job_templates");
            
            for (int i = 0; i < jsonArrayTemplates.length(); i++) {
                JSONObjectWrapper jsonObjectTemplate = new JSONObjectWrapper(jsonArrayTemplates.getJSONObject(i));
                System.out.println(jsonObjectTemplate.getString("name", "") + " (" + jsonObjectTemplate.getInt("job_template_id") + ")");
              }
        } catch (GeopalClientException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        

    }

}
