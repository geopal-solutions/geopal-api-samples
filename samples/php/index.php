<?php

namespace GeopalApiSample;

// This script may only be called from the command line
if (php_sapi_name() !== 'cli') {
    echo 'Please run this script from the command line.';
    echo "\n\nType <pre>php index help</pre> for more information";
    die();
}

// Load files
require_once 'GeopalClient.php';
require_once 'GeopalExample.php';
require_once 'GeopalInterface.php';

// Create the example logic
$example = new GeopalExample(
    new GeopalClient(
        'http://geopal.local/'
    )
);

// create interface object
$interface = new GeopalInterface();

// Create a request based on user input
$example->request($interface->getAction());

// Display result
echo $example->getOutput();

// Display menu at the end
$interface->showMenu();