<?php
function OpenCon()
{
    $dbhost = "localhost";
    $dbuser = "root";
    $dbpass = "root";
    $dbname ="db_clients_erp";
    $conn = new mysqli($dbhost, $dbuser, $dbpass,$dbname) or die("Connect failed: %s\n". $conn -> error);
    return $conn;
}
function ReadData($conn, $table)
{
    $conn = OpenCon();
    $data = ReadData($conn, "nom_de_votre_table");}


function CloseCon($conn)
{
    $conn -> close();
}
?>
