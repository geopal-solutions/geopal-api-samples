
package GeopalJobSample;

import org.apache.commons.codec.binary.Base64;
import org.apache.commons.codec.binary.Hex;
import org.apache.http.HttpEntity;
import org.apache.http.HttpStatus;
import org.apache.http.NameValuePair;
import org.apache.http.ParseException;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpPut;
import org.apache.http.client.utils.URLEncodedUtils;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

import java.io.IOException;
import java.util.List;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

public class GeopalClient
{
    private static final String DEFAULT_PRIVATEKEY = "";
    private static final String DEFAULT_EMPLOYEEID = "";
    private static final String GEOPAL_BASE_URL = "https://app.geopalsolutions.com/";

    private String uri = "";
    private String employeeId = DEFAULT_EMPLOYEEID;
    private String privateKey = DEFAULT_PRIVATEKEY;

    private String lastResponse;

    public GeopalClient()
    {

    }

    public GeopalClient(String uri)
    {
        setUri(uri);
    }

    public GeopalClient get( List<NameValuePair> params) throws GeopalClientException {

	    CloseableHttpClient httpclient = null;
	    try {
	     httpclient = HttpClients.createDefault();
	    
        String paramString = URLEncodedUtils.format(params, "utf-8");
        String url = getApiUrl(uri) + "?" + paramString;

        HttpGet httpget = new HttpGet(url);
        httpget = updateHTTPClientWithSignature(httpget, uri);

        CloseableHttpResponse response = null;
        try {
            response = httpclient.execute(httpget);
        } catch (ClientProtocolException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        } finally {
            try {
                response.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
        }

        if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
            throw new GeopalClientException();
        } 

        HttpEntity entity = response.getEntity();
        try {
            lastResponse = EntityUtils.toString(entity);
        } catch (ParseException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        }

            return this;
	    } finally {
	        try {
                httpclient.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
	    }
    }
    
    
    
    
    public GeopalClient put( List<NameValuePair> params) throws GeopalClientException {

        CloseableHttpClient httpclient = null;
        try {
         httpclient = HttpClients.createDefault();
        
        String url = getApiUrl(uri);

        HttpPut httpPut = new HttpPut(url);
        httpPut = updateHTTPClientWithSignature(httpPut, uri);

        CloseableHttpResponse response = null;
        try {
            httpPut.setEntity(new UrlEncodedFormEntity(params, "UTF-8"));
            
            response = httpclient.execute(httpPut);
        } catch (ClientProtocolException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        } finally {
            try {
                response.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
        }

        if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
            throw new GeopalClientException();
        } 

        HttpEntity entity = response.getEntity();
        try {
            lastResponse = EntityUtils.toString(entity);
        } catch (ParseException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        }

            return this;
        } finally {
            try {
                httpclient.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
        }
    }
    
    
    public GeopalClient post( List<NameValuePair> params) throws GeopalClientException {

        CloseableHttpClient httpclient = null;
        try {
         httpclient = HttpClients.createDefault();
        
        String url = getApiUrl(uri);

        HttpPost httpPost = new HttpPost(url);
        httpPost = updateHTTPClientWithSignature(httpPost, uri);

        CloseableHttpResponse response = null;
        try {
            httpPost.setEntity(new UrlEncodedFormEntity(params, "UTF-8"));
            
            response = httpclient.execute(httpPost);
        } catch (ClientProtocolException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        } finally {
            try {
                response.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
        }

        if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
            throw new GeopalClientException();
        } 

        HttpEntity entity = response.getEntity();
        try {
            lastResponse = EntityUtils.toString(entity);
        } catch (ParseException e) {
            throw new GeopalClientException();
        } catch (IOException e) {
            throw new GeopalClientException();
        }

            return this;
        } finally {
            try {
                httpclient.close();
            } catch (IOException e) {
                throw new GeopalClientException();
            }
        }
    }


    
    public final void setUri(String uri)
    {
        this.uri = uri;
    }

    public final void setEmployeeId(String employeeId)
    {
        this.employeeId = employeeId;
    }

    public final void setPrivateKey(String privatekey)
    {
        this.privateKey = privatekey;
    }



    private HttpGet updateHTTPClientWithSignature(HttpGet httpget, String uri)
    {
        String method = "get";
        java.util.Date now = new java.util.Date();
        String timestamp = String.format("{0:ddd, dd MMM yyyy hh:mm:ss }", now) + "GMT";
        String signature = getSignature(method + uri + employeeId + timestamp, privateKey);
        httpget.setHeader("GEOPAL_SIGNATURE", signature);
        httpget.setHeader("GEOPAL_TIMESTAMP", timestamp);
        httpget.setHeader("GEOPAL_EMPLOYEEID", employeeId);

        return httpget;

    }
    
    
    private HttpPut updateHTTPClientWithSignature(HttpPut httpput, String uri)
    {
        String method = "put";
        java.util.Date now = new java.util.Date();
        String timestamp = String.format("{0:ddd, dd MMM yyyy hh:mm:ss }", now) + "GMT";
        String signature = getSignature(method + uri + employeeId + timestamp, privateKey);
        httpput.setHeader("GEOPAL_SIGNATURE", signature);
        httpput.setHeader("GEOPAL_TIMESTAMP", timestamp);
        httpput.setHeader("GEOPAL_EMPLOYEEID", employeeId);

        return httpput;

    }
    
    
    private HttpPost updateHTTPClientWithSignature(HttpPost httpPost, String uri)
    {
        String method = "post";
        java.util.Date now = new java.util.Date();
        String timestamp = String.format("{0:ddd, dd MMM yyyy hh:mm:ss }", now) + "GMT";
        String signature = getSignature(method + uri + employeeId + timestamp, privateKey);
        httpPost.setHeader("GEOPAL_SIGNATURE", signature);
        httpPost.setHeader("GEOPAL_TIMESTAMP", timestamp);
        httpPost.setHeader("GEOPAL_EMPLOYEEID", employeeId);

        return httpPost;

    }

    private String getSignature(String signtext, String privateKey)
    {
        String test = getHMAC256(privateKey, signtext);
        return Base64.encodeBase64String(test.getBytes());
    }
    
    public String getHMAC256(String pwd, String inputdata) {
        String temp = null;
        SecretKeySpec keySpec = new SecretKeySpec(pwd.getBytes(), "HmacSHA256");
        try {
            Mac mac = Mac.getInstance("HmacSHA256");
            mac.init(keySpec);
            //update method adds the given byte to the Mac's input data. 
            mac.update(inputdata.getBytes());
            byte[] m = mac.doFinal();
            //The base64-encoder in Commons Codec
            temp = new String(Hex.encodeHex(m));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return temp;
    }

    private String getApiUrl(String uri) {
        return GEOPAL_BASE_URL + uri;
    }

    private String getApiUrl(String uri, int param1) {
        return GEOPAL_BASE_URL + uri + "/" + String.valueOf(param1);
    }

    private String getApiUrl() {
        return GEOPAL_BASE_URL;
    }

}
