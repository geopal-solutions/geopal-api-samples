Imports System.Text
Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports System.Net

Namespace GeopalJobSample
	Public Class GeopalClient
		Private Const DEFAULT_PRIVATEKEY As [String] = ""
		Private Const DEFAULT_EMPLOYEEID As [String] = ""
		Private Const GEOPAL_BASE_URL As [String] = "https://app.geopalsolutions.com/"

		Private uri As [String] = ""
		Private employeeId As [String] = DEFAULT_EMPLOYEEID
		Private privateKey As [String] = DEFAULT_PRIVATEKEY

		Public Sub New()
		End Sub

		Public Sub New(uri As [String])
			setUri(uri)
		End Sub


		Public Function post(pairs As NameValueCollection) As String
			Dim wb As WebClient = generateWebClient("POST", Me.uri)
			Return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "POST", pairs))
		End Function

		Public Function put(pairs As NameValueCollection) As String
			Dim wb As WebClient = generateWebClient("PUT", Me.uri)
			Return Encoding.ASCII.GetString(wb.UploadValues(getUrl(), "PUT", pairs))
		End Function

		Public Function [get](urlPairs As [String]) As String
			Dim wb As WebClient = generateWebClient("GET", Me.uri)
			Return wb.DownloadString(getUrl() & "?" & urlPairs)
		End Function

		Public Function [get]() As String
			Dim wb As WebClient = generateWebClient("GET", Me.uri)
			Return wb.DownloadString(getUrl())
		End Function

		Public Sub downloadFile(urlPairs As [String], fileLocation As String)
			Dim wb As WebClient = generateWebClient("GET", Me.uri)
			wb.DownloadFile(getUrl() & "?" & urlPairs, fileLocation)
		End Sub

		Public Sub setUri(uri As [String])
			Me.uri = uri
		End Sub

		Public Sub setEmployeeId(employeeId As String)
			Me.employeeId = employeeId
		End Sub

		Public Sub setPrivateKey(privatekey As String)
			Me.privateKey = privatekey
		End Sub

		Private Function getUrl() As [String]
			Return GEOPAL_BASE_URL & Me.uri
		End Function

		Private Function generateWebClient(method As [String], uri As [String]) As WebClient
			method = method.ToLower()
			Dim now As DateTime = DateTime.Now
			Dim timestamp As [String] = now.ToString("ddd, dd MMM yyyy hh:mm:ss ") & "GMT"
			Dim signature As String = GetSignature(method & uri & employeeId & timestamp, privateKey)

			Dim wb As New WebClient()
			Dim wbHeaders As New WebHeaderCollection()
			wbHeaders.Add("GEOPAL_SIGNATURE", signature)
			wbHeaders.Add("GEOPAL_TIMESTAMP", timestamp)
			wbHeaders.Add("GEOPAL_EMPLOYEEID", employeeId)

			wb.Headers = wbHeaders

			Return wb

		End Function

		Private Function GetSignature(signtext As String, privateKey As String) As String
			Dim encoding As New System.Text.ASCIIEncoding()

			Dim keybytes As Byte() = encoding.GetBytes(privateKey)
			Dim signbytes As Byte() = encoding.GetBytes(signtext)

			Dim hmacsha256 As New HMACSHA256(keybytes)

			Return EncodeTo64(ByteToString(hmacsha256.ComputeHash(signbytes)).ToLower())
		End Function

		Private Function EncodeTo64(toEncode As String) As String
			Dim toEncodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode)
			Dim returnValue As String = System.Convert.ToBase64String(toEncodeAsBytes)
			Return returnValue
		End Function

		Private Shared Function ByteToString(buff As Byte()) As String
			Dim sbinary As String = ""

			For i As Integer = 0 To buff.Length - 1
					' hex format
				sbinary += buff(i).ToString("X2")
			Next
			Return (sbinary)
		End Function
	End Class
End Namespace