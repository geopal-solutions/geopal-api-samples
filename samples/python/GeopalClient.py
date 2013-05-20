#Sample Geopal api application

from email import utils
import time
import datetime
import json
import hmac
import hashlib
import base64
import urllib
import urllib2
import dicttoxml

# api base url
GEOPAL_BASE_URL = 'https://app.geopalsolutions.com/'

class GeopalClient():
    __uri = None
    __base_uri = None
    __signature_text = None
    __method = 'GET'
    employee_id = None
    private_key = None

    # sets uri
    # @param string uri
    def __setUri(self, uri):
        self.__uri = uri

    # returns __base_uri
    # @return string
    def __getUri(self):
        return self.__uri

    # sets uri
    # @param string uri
    def __setBaseUri(self, uri):
        self.__base_uri = uri

    # returns __base_uri
    # @return string
    def __getBaseUri(self):
        return self.__base_uri

    # sets employee_id
    # @param integer e_id
    def setEmployeeId(self, e_id):
        self.employee_id = e_id

    # returns employee_id
    # @return integer
    def getEmployeeId(self):
        return self.employee_id

    # sets private key
    # @param string key
    def setPrivateKey(self, key):
        self.private_key = key

    # returns private key
    # @return string
    def getPrivateKey(self):
        return self.private_key

    # returns whole api address including http:// part
    # @return string
    def __getUrl(self):
        return GEOPAL_BASE_URL + self.__getBaseUri();

    # sets signature text
    # @param string signature_text
    # @return string
    def __setSignatureText(self, signature_text):
        self.__signature_text = signature_text

    # returns signature text
    # @return string
    def __getSignatureText(self):
        return self.__signature_text

    # sets method type
    # @param string method - http method like post, get ...
    # @return string
    def __setMethod(self, method):
        self.__method = method

    # returns method type
    # @return string
    def __getMethod(self):
        return self.__method

    # generates signature string for authentication
    # @param string method
    # @param string  uri
    # @param integer  employee_id
    # @return string
    def __generateSignatureString(self, method, uri, employee_id):
        return method.lower() + uri + employee_id.__str__() + self.getTimeStamp()

    # generates base64 hash for given signature
    # @param string sign_text
    # @param string  private_key
    # @return string
    def __generateSignature(self, sign_text, private_key):
        dig = hmac.new(private_key, sign_text, hashlib.sha256).hexdigest()
        sign = base64.b64encode(dig)
        return sign

    # sets http header credentials
    # @param object req - urllib2 request object
    def __setHeaderCredentials(self, req):
        req.add_header("GEOPAL_SIGNATURE", self.__getSignatureText())
        req.add_header("GEOPAL_TIMESTAMP", self.getTimeStamp())
        req.add_header("GEOPAL_EMPLOYEEID", self.getEmployeeId())

    # makes http request according to given method
    # @param string method - request type
    # @param string  uri - uri part
    # @param dict - additional data
    # @return string
    def makeRequest(self, method, uri, data=None):
        self.__setMethod(method)
        self.__setBaseUri(uri)
        self.__setUri(uri.split('?')[0])

        sign_text = self.__generateSignatureString(
            self.__getMethod(),
            self.__getUri(),
            self.getEmployeeId()
        )

        self.__setSignatureText(
            self.__generateSignature(
                sign_text,
                self.getPrivateKey()
            )
        )

        if (data):
            request = urllib2.Request(self.__getUrl(), urllib.urlencode(data))
        else:
            request = urllib2.Request(self.__getUrl())

        self.__setHeaderCredentials(request)
        return urllib2.urlopen(request).read()

    # returns time stamp in RFC 2822 format
    # @return string
    def getTimeStamp(self):
        now_tuple = datetime.datetime.now().timetuple()
        now_timestamp = time.mktime(now_tuple)
        return utils.formatdate(now_timestamp).__str__().replace('-', '+')


class GeopalActions(GeopalClient):

    # creates job based on template_id
    # @param integer template_id
    # @return string
    def createAJob(self, template_id):
        job = json.loads(self.makeRequest(
            'POST',
            'api/jobs/createandassign',
            {'template_id': template_id.__str__()}
        ))

        return job

    # returns job based on job_id
    # @param integer job_id
    # @return string
    def getAJob(self, job_id):
        output = self.makeRequest(
            'GET',
            'api/jobs/get?job_id=' + job_id.__str__()
        )

        job = json.loads(output.__str__())['job']
        print 'id: {0}, priority_color: {1}, rate_per_hour: {2}, created_on: {3}, prefered_start_date_time: {4}, priority_text: {5}, duration: {6}, start_date_time: {7}'.format(
            job['id'],
            job['priority_color'],
            job['rate_per_hour'],
            job['created_on'],
            job['prefered_start_date_time'],
            job['priority_text'],
            job['duration'],
            job['start_date_time']
        )

        return job

    # returns list of templates
    # @return string
    def listOfTemplates(self):
        output = self.makeRequest(
            'GET',
            'api/jobtemplates/all'
        )

        templates = json.loads(output.__str__())['job_templates']
        for t in templates:
             print 'job_template_id: {0}, name:{1}, is_deleted: {2}, updated_on: {3}'.format(
                 t['job_template_id'],
                 t['name'],
                 t['is_deleted'],
                 t['updated_on']
             )

        return templates

    # returns job template based on template_id
    # @param integer template_id
    # @return string
    def readAJobTemplate(self, template_id):
        output = self.makeRequest(
            'GET',
            'api/jobtemplates/get?template_id=' + template_id.__str__()
        )

        template = json.loads(output.__str__())['job_template']

        print 'estimate_job_duration: {0}, description: {1}, company_id: {2}, updated_by: {3}'.format(
            template['estimate_job_duration'],
            template['description'],
            template['company_id'],
            template['updated_by']
        )

        return template

    # returns jobs based on date range
    # @param string start_date - data in format YYYY-mm-dd HH:ii:ss passed as string
    # @param string end_date - data in format YYYY-mm-dd HH:ii:ss passed as string
    # @return string
    def readsJobsByDateRange(self, start_date, end_date):
        params = urllib.urlencode({'date_time_from': start_date.__str__(), 'date_time_to': end_date.__str__()}).__str__()
        output = self.makeRequest(
            'GET',
            'api/jobsearch/ids?' + params
        )

        for job in json.loads(output.__str__())['jobs']:
            print 'id:{0}'.format(job['id'])
            self.getAJob(job['id'])

        return output

    # returns employees list in JSON format
    # @return string
    def getEmployees(self):
        output = self.makeRequest(
            'GET',
            'api/employees/all'
        )

        for emp in json.loads(output.__str__())['employees']:
            print 'id:{0}, firstName: {1}, lastName: {2}, title: {3}, address: {4}, lat: {5}, lng: {6}'.format(
                emp['id'],
                emp['first_name'],
                emp['last_name'],
                emp['title'],
                emp['address'],
                emp['lat'],
                emp['lng']
            )

        return json.loads(output.__str__())['employees']


    # returns employees list in XML format
    # @return string
    def getEmployeesXml(self):
        output = self.makeRequest(
            'GET',
            'api/employees/all'
        )
        json_str = json.loads(output)
        return dicttoxml.dicttoxml(json_str)


class GeopalInterface(GeopalActions):

    # initializes class
    def __init__(self):
        print 'GEOPAL Sample'
        print 'Please enter Employee ID:'
        employee_id = int(raw_input())
        print 'Please enter private key:'
        private_key = raw_input()

        self.setPrivateKey(private_key)
        self.setEmployeeId(employee_id)

        action = 0
        while action != -1:
            action = int(self.printMenu())

            if action == 1:
                self.uiCreateAJob()
            elif action == 2:
                self.uiGetAJob()
            elif action == 3:
                self.uiListOfTemplates()
            elif action == 4:
                self.uiReadAJobTemplate()
            elif action == 5:
                self.uiReadsJobsByDateRange()
            elif action == 6:
                self.uiGetEmployees()
            elif action == 7:
                self.uiGetEmployeesXml()
            else:
                exit()

    # prints basic text menu
    # @return integer
    def printMenu(self):
        print '1 - Create a job'
        print '2 - Read a job'
        print '3 - List of job templates'
        print '4 - Read job template'
        print '5 - Read jobs between date range'
        print '6 - Employees list'
        print '7 - Employees list in XML'
        print 'Select action:'
        return int(raw_input())

    # prints results for createAJob
    def uiCreateAJob(self):
        print 'Please enter template id:'
        print self.createAJob(raw_input())

    # prints results for getAJob
    def uiGetAJob(self):
        print 'Please enter a template id:'
        self.getAJob(raw_input())

    # prints results for listOfTemplates
    def uiListOfTemplates(self):
        self.listOfTemplates()

    # prints results for readAJobTemplate
    def uiReadAJobTemplate(self):
        print 'Please enter a job template id:'
        self.readAJobTemplate(raw_input())

    # prints results for readsJobsByDateRange
    def uiReadsJobsByDateRange(self):
        print 'Please enter a from date (yyyy-MM-dd HH:mm:ss) see http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx"'
        start_date = raw_input()
        print 'Please enter a to date (yyyy-MM-dd HH:mm:ss)'
        end_date = raw_input()
        self.readsJobsByDateRange(start_date, end_date)

    # prints results for getEmployees
    def uiGetEmployees(self):
        self.getEmployees()

    # prints results for getEmployeesXml
    def uiGetEmployeesXml(self):
        print self.getEmployeesXml()


GeopalInterface()
