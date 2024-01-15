<?php

$servername = "localhost:6033";
$username = "root";
$password = "root";
$dbname = "db_clients_erp";
$db = new mysqli($servername, $username, $password, $dbname);


$sql = "SELECT idClient, CliUsername, CliFirstName, CliLastName, CliCompanyName, CliAddress, CLiCity, CliLocality, CliCountry, CliZip, CliPhoneFirst, CliPhoneSecond, CliEmail, CliWeb FROM clients ORDER BY CliLastName ASC";
$result = $db->query($sql);

$idClient=[];
$username=[];
$firstName=[];
$lastName=[];
$companyName=[];
$adress =[];
$city  =[];
$locality  =[];
$country =[];
$zip=[];
$phone1 =[];
$phone2=[];
$email=[];
$web=[];

//Parcourir les donées
while ($row = $result->fetch_assoc()) {
// Attribuez chaque colonne à une variable
$idClient[] = $row["idClient"];
$username[] =$row["CliUsername"];
$firstName[] = $row["CliFirstName"];
$lastName[] = $row["CliLastName"];
$companyName[] = $row["CliCompanyName"];
$adress[] = $row["CliAddress"];
$city[] = $row["CLiCity"];
$locality[]= $row["CliLocality"];
$country[] = $row["CliCountry"];
$zip[] =$row["CliZip"];
$phone1[] =$row["CliPhoneFirst"];
$phone2[] =$row["CliPhoneSecond"];
$email[]=$row["CliEmail"];
$web[]=$row["CliWeb"];
}

//$db->close();
?>



<html lang="fr">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="https://cdn.jsdelivr.net/npm/daisyui@4.4.20/dist/full.min.css" rel="stylesheet" type="text/css" />
        <style>
            body {
                color: white; /* Définit la couleur du texte pour l'ensemble du corps de la page */
            }
        </style>
    </head>
<body>
<div class="overflow-x-auto">
    <table class="table table-xs table-pin-rows table-pin-cols">
        <thead>

        <tr>

            <td>ID</td>
            <td>Username</td>
            <td>First Name</td>
            <td>Last Name</td>
            <td>Compagny name</td>
            <td>Address</td>
            <td>City</td>
            <td>Locality</td>
            <td>Country</td>
            <td>Zip</td>
            <td>Phone first number</td>
            <td>Phone second Number</td>
            <td>Email</td>
            <td>Web</td>

        </tr>
        </thead>
        <tbody>


        <?php
        for ($i = 0; $i < sizeof($idClient); $i++) {
            ?>

            <html>
            <tr>
                <td><?php echo $idClient[$i]; ?></td>
                <td><?php echo $username[$i]; ?></td>
                <td><?php echo $firstName[$i]; ?></td>
                <td><?php echo $lastName[$i]; ?></td>
                <td><?php echo $companyName[$i]; ?></td>
                <td><?php echo $adress[$i]; ?></td>
                <td><?php echo $city[$i]; ?></td>
                <td><?php echo $locality[$i]; ?></td>
                <td><?php echo $country[$i]; ?></td>
                <td><?php echo $zip[$i]; ?></td>
                <td><?php echo $phone1[$i]; ?></td>
                <td><?php echo $phone2[$i]; ?></td>
                <td><?php echo $email[$i]; ?></td>
                <td><?php echo $web[$i]; ?></td>

            </tr>
            </html>
            <?php
        }
        ?>

    </table>
</div>
</html>