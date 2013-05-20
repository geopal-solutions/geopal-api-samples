using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Net;

namespace GeopalJobSample
{
	public class GeopalClient
	{
		private const String DEFAULT_PRIVATEKEY = "";
		private const String DEFAULT_EMPLOYEEID = "";
		private const String GEOPAL_BASE_URL = "https://app.geopalsolutions.com/";

		private String uri = "";
		private String employeeId = DEFAULT_EMPLOYEEID;
		private String privateKey = DEFAULT_PRIVATEKEY;

		public GeopalClient ()
		{
		}

		public GeopalClient (String uri)
		{
			setUri(uri);
		}


		public string post(NameValueCollection pairs) 
		{
			WebClient wb = generateWebClient("POST", this.uri);
			return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "POST", pairs));
		}

		public string put(NameValueCollection pairs)
		{
			WebClient wb = generateWebClient("PUT", this.uri);
			return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "PUT", pairs));
		}

		public string get(String urlPairs)
		{
			WebClient wb = generateWebClient("GET", this.uri);
			return wb.DownloadString(getUrl()+"?"+urlPairs);
		}

		public string get ()
		{
			WebClient wb = generateWebClient ("GET", this.uri);
			return wb.DownloadString (getUrl ());
		}

		public void downloadFile(String urlPairs, string fileLocation)
		{
			WebClient wb = generateWebClient("GET", this.uri);
			wb.DownloadFile(getUrl()+"?"+urlPairs, fileLocation);
		}

		public void setUri (String uri)
		{
			this.uri = uri;
		}

		public void setEmployeeId (string employeeId)
		{
			this.employeeId = employeeId;
		}

		public void setPrivateKey (string privatekey)
		{
			this.privateKey = privatekey;
		}

		private String getUrl ()
		{
			return GEOPAL_BASE_URL + this.uri;
		}

		private WebClient generateWebClient(String method, String uri)
		{
			method = method.ToLower();
			DateTime now = DateTime.Now;
			String timestamp = now.ToString("ddd, dd MMM yyyy hh:mm:ss ")+"GMT";
			string signature = GetSignature(method + uri + employeeId + timestamp, privateKey);

			WebClient wb = new WebClient();
			WebHeaderCollection wbHeaders = new WebHeaderCollection();
			wbHeaders.Add("GEOPAL_SIGNATURE", signature);
			wbHeaders.Add("GEOPAL_TIMESTAMP", timestamp);
			wbHeaders.Add("GEOPAL_EMPLOYEEID", employeeId);

			wb.Headers = wbHeaders;

			return wb;

		}

		private string GetSignature(string signtext, string privateKey)
		{
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			
			byte[] keybytes = encoding.GetBytes(privateKey);
			byte[] signbytes = encoding.GetBytes(signtext);
			
			HMACSHA256 hmacsha256 = new HMACSHA256(keybytes);
			
			return EncodeTo64(ByteToString(hmacsha256.ComputeHash(signbytes)).ToLower());
		}
		
		private string EncodeTo64(string toEncode)
		{
			byte[] toEncodeAsBytes
				= System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
			string returnValue
				= System.Convert.ToBase64String(toEncodeAsBytes);
			return returnValue;
		}
		
		private static string ByteToString(byte[] buff)
		{
			string sbinary = "";
			
			for (int i = 0; i < buff.Length; i++)
			{
				sbinary += buff[i].ToString("X2"); // hex format
			}
			return (sbinary);
		}
	}
}

