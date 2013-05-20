<?php

namespace GeopalApiSample;

class GeopalClient
{


    ///// Constants //////


    const DEFAULT_EMPLOYEE_ID = '';
    const DEFAULT_PRIVATE_KEY = '';
    const GEOPAL_BASE_URL = 'https://app.geopalsolutions.com/';


    ///// Properties /////


    /**
     * @var string
     */
    private $uri = self::GEOPAL_BASE_URL;

    /**
     * @var string
     */
    private $employeeId = self::DEFAULT_EMPLOYEE_ID;

    /**
     * @var string
     */
    private $privateKey = self::DEFAULT_PRIVATE_KEY;

    /**
     * @var resource
     */
    private $curl = null;


    ///// Constructor, destructor /////


    public function __construct($uri = '')
    {
        if (!is_null($uri)) {
            $this->uri = $uri;
        }

        $this->curl = curl_init();
    }

    public function __destruct()
    {
        curl_close($this->curl);
    }


    ///// Getter, setter /////


    public function __get($property)
    {
        if (isset($this->{$property})) {
            return $this->{$property};
        } else {
            return null;
        }
    }

    public function __set($property, $value)
    {
        
    }


    ///// Request logic /////




}