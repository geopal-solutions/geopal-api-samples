<?php

namespace GeopalApiSample;

/**
 * Class GeopalInterface
 *
 * User interface class for the sample
 *
 * @package Geopal\Api\Sample
 */

class GeopalInterface
{
    /**
     * @var int
     */
    private $userChoice = null;

    /**
     * @var array
     */
    private $menu = array(
        1 => 'Create A Job',
        2 => 'Read A Job',
        3 => 'List All Job Templates',
        4 => 'Read Job Template',
        5 => 'Read Jobs Between Date Range',
        6 => 'List Employees',
        7 => 'List Employees and convert output to XML'
    );

    public function __construct()
    {
        $action = (isset($_POST['action']) && !empty($_POST['action'])) ? $_POST['action'] : null;

        if (!is_null($action) || (strtolower($action) !== 'help')) {
            $this->userChoice = (int)$action;
        }

    }

    /**
     * Returns requested action
     *
     * @return int|null
     */
    public function getAction()
    {
        return $this->userChoice;
    }

    /**
     * Displays menu
     */
    public function showMenu()
    {
        echo "\nUsage:";
        echo "\nphp " . basename($_SERVER['PHP_SELF']) . " <option> <employee_id> <private_key>";
        echo "\n\nOptions:";

        foreach ($this->menu as $action => $item) {
            echo "\n\t" . $action . ": " . $item;
        }

        echo "\n\n";
    }

}