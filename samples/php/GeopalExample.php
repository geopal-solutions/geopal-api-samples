<?php

namespace GeopalApiSample;

class GeopalExample
{
    /**
     * @var GeopalClient
     */
    private $client = null;

    /**
     * @var string
     */
    private $response = '';

    /**
     * @var bool
     */
    private $xmlOutput = false;

    /**
     * Constructor
     *
     * @param GeopalClient $client
     */
    public function __construct(GeopalClient $client = null)
    {
        $this->client = $client;
    }

    /**
     * Displays output
     *
     * @return string
     */
    public function getOutput()
    {
        if (!empty($this->response)) {
            if ($this->xmlOutput) {
                // Do xml conversion (stub)
                var_dump($this->response);
            } else {
                // Decode json output (stub)
                var_dump($this->response);
            }
        }
    }

    /**
     * Processes user request and stores result
     *
     * @param int $action
     */
    public function request($action = null)
    {
        if (!is_null($action) && !is_null($this->client)) {
            // Make request
            $this->response = '';
        }
    }
}