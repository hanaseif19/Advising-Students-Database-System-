<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorMainPage.aspx.cs" Inherits="WebApplication2.AdvisorMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style>
    /* Reset default margin and padding */
   body, ul {
    margin: 0;
    padding: 0;
}

/* Style the navigation bar */
ul.navbar {
    list-style-type: none;
    background-color: black; /* Background color of the navbar */
    overflow: hidden;
    width: 100%; /* Make the navigation bar 100% width */
}

ul.navbar li {
    float: left; /* Float the list items horizontally */
    margin-right: 30px; /* Adjust the right margin to increase space between items */
}

ul.navbar li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px; /* Adjust padding to your liking */
    text-decoration: solid;
    font-size: 16px; /* Adjust the font size */
    font-family: Arial, sans-serif; /* Specify the font family */
}

/* Change color on hover */
ul.navbar li a:hover {
    background-color: black; /* Background color on hover */
}

.viewList {
    width: 220px; /* Make the viewList wider */
    color: white;
    background-color: black;
    box-shadow: rgba(0, 0, 0, 0);
    transition: background-color 0.3s;
}

.viewList {
    padding: 10px 20px;
    width: 100%;
    padding: 10px;
    cursor: pointer;
    color: white;
    background-color: black;
    box-shadow: rgba(0, 0, 0, 0);
    transition: background-color 0.3s;
}

.others {
    width: 220px; /* Make the others wider */
}

.others {
    width: 100%;
    padding: 10px;
    cursor: pointer;
}

.Viewcontent {
    display: none;
    position: absolute;
    background-color: black;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px black;
    z-index: 1;
    color: white;
}

.Viewcontent a {
    padding: 12px 16px;
    display: block;
    text-decoration: none;
    color: white;
    background-color: black;
}

.Viewcontent a:hover {
    background-color: black;
}

.viewList:hover .Viewcontent {
    display: block;
}
  </style>
 </head>
    
  <body>
  <form id="form2" runat="server">
<ul class="navbar">
  <li>  <div class="viewList" >
 <a href="AdvisorMainPage.aspx">Home</a></li></div>
<li><div class="viewList" >
    <a href="AdvisorMainPage.aspx">Requests</a>
    <div class="Viewcontent">
  <a href="AdvisorAllRequests.aspx">All Requests</a>
  <a href="AdvisorPendingRequests.aspx">Pending Requests</a>
</div></div></li>
  <li>  <div class="viewList" >
    <a href="AdvisorMainPage.aspx">Graduation Plan</a>
    <div class="Viewcontent">
  <a href="CreateGradPlan.aspx">Create </a>
  <a href="AdvisorDeleteCourse.aspx">Delete Course</a>
  <a href="AddCoursesGradPlan.aspx">Add Course</a>
  <a href="UpdateGradDate.aspx">Update Graduation Date</a>

</div></div></li>
  <li>
<div class="viewList">
  <a href="AdvisorMainPage.aspx">View</a>
  <div class="Viewcontent">
    <a href="AdivsorAllStudents.aspx">All Students</a>
    <a href="AdvisorStudentsMajors.aspx">Major Students with Courses</a>


  </div>
</div></li>
 
</ul>

    </form>
</body>
</html>