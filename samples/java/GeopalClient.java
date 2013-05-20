package GeopalJobSample;

public class GeopalClient
{
	private static final String DEFAULT_PRIVATEKEY = "";
	private static final String DEFAULT_EMPLOYEEID = "";
	private static final String GEOPAL_BASE_URL = "https://app.geopalsolutions.com/";

	private String uri = "";
	private String employeeId = DEFAULT_EMPLOYEEID;
	private String privateKey = DEFAULT_PRIVATEKEY;

	public GeopalClient()
	{
	}

	public GeopalClient(String uri)
	{
		setUri(uri);
	}


	public final String post(NameValueCollection pairs)
	{
		WebClient wb = generateWebClient("POST", this.uri);
		return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "POST", pairs));
	}

	public final String put(NameValueCollection pairs)
	{
		WebClient wb = generateWebClient("PUT", this.uri);
		return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "PUT", pairs));
	}

	public final String get(String urlPairs)
	{
		WebClient wb = generateWebClient("GET", this.uri);
		return wb.DownloadString(getUrl() + "?" + urlPairs);
	}

	public final String get()
	{
		WebClient wb = generateWebClient("GET", this.uri);
		return wb.DownloadString(getUrl());
	}

	public final void downloadFile(String urlPairs, String fileLocation)
	{
		WebClient wb = generateWebClient("GET", this.uri);
		wb.DownloadFile(getUrl() + "?" + urlPairs, fileLocation);
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

	private String getUrl()
	{
		return GEOPAL_BASE_URL + this.uri;
	}

	private WebClient generateWebClient(String method, String uri)
	{
		method = method.toLowerCase();
		java.util.Date now = new java.util.Date();
//C# TO JAVA CONVERTER TODO TASK: The '0:ddd, dd MMM yyyy hh:mm:ss ' format specifier is not converted to Java:
		String timestamp = String.format("{0:ddd, dd MMM yyyy hh:mm:ss }", now) + "GMT";
		String signature = GetSignature(method + uri + employeeId + timestamp, privateKey);

		WebClient wb = new WebClient();
		WebHeaderCollection wbHeaders = new WebHeaderCollection();
		wbHeaders.Add("GEOPAL_SIGNATURE", signature);
		wbHeaders.Add("GEOPAL_TIMESTAMP", timestamp);
		wbHeaders.Add("GEOPAL_EMPLOYEEID", employeeId);

		wb.Headers = wbHeaders;

		return wb;

	}

	private String GetSignature(String signtext, String privateKey)
	{
		System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

//C# TO JAVA CONVERTER WARNING: Unsigned integer types have no direct equivalent in Java:
//ORIGINAL LINE: byte[] keybytes = encoding.GetBytes(privateKey);
		byte[] keybytes = encoding.GetBytes(privateKey);
//C# TO JAVA CONVERTER WARNING: Unsigned integer types have no direct equivalent in Java:
//ORIGINAL LINE: byte[] signbytes = encoding.GetBytes(signtext);
		byte[] signbytes = encoding.GetBytes(signtext);

		HMACSHA256 hmacsha256 = new HMACSHA256(keybytes);

		return EncodeTo64(ByteToString(hmacsha256.ComputeHash(signbytes)).toLowerCase());
	}

	private String EncodeTo64(String toEncode)
	{
//C# TO JAVA CONVERTER WARNING: Unsigned integer types have no direct equivalent in Java:
//ORIGINAL LINE: byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
		byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
		String returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
		return returnValue;
	}

//C# TO JAVA CONVERTER WARNING: Unsigned integer types have no direct equivalent in Java:
//ORIGINAL LINE: private static string ByteToString(byte[] buff)
	private static String ByteToString(byte[] buff)
	{
		String sbinary = "";

		for (int i = 0; i < buff.length; i++)
		{
			sbinary += String.format("%02X", buff[i]); // hex format
		}
		return (sbinary);
	}
}