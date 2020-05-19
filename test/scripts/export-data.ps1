# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$run = "after"

$sql = "select * from analytics.ContactPersonDimension order by contactlastname, contactfirstname, lastmodifieddate"
$file = "$run/ContactPersonDimension.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentdataauthorization"
$file = "$run/studentdataauthorization.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentdimension order by studentlastname, studentfirstname, studentmiddlename, schoolkey"
$file = "$run/studentdimension.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentearlywarningfact"
$file = "$run/studentearlywarningfact.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentprogramevent"
$file = "$run/studentprogramevent.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentprogramfact"
$file = "$run/studentprogramfact.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentsectiondimension"
$file = "$run/studentsectiondimension.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.studentsectiongradefact"
$file = "$run/studentsectiongradefact.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.userauthorization"
$file = "$run/userauthorization.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.userdimension order by useremail"
$file = "$run/userdimension.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.userstudentdataauthorization"
$file = "$run/userstudentdataauthorization.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","

$sql = "select * from analytics.userstudentdataauthorization"
$file = "$run/userstudentdataauthorization.txt"
bcp $sql queryout $file -d "Ed-Fi-Glendale-v22" -c -T -t ","