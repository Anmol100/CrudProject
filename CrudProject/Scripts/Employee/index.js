$(document).ready(function () {
    $('#EmpTable').DataTable({
        "ajax": {
            "url": "/Employees/loaddata",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Id", "autoWidth": true },
            { "data": "Name", "autoWidth": true },
            { "data": "Emp_no", "autoWidth": true },
            { "data": "Branch", "autoWidth": true },
            { "data": "Department", "autoWidth": true },
            {
                "data": null, render: function (data, type, row) {
                    return '<a href="/Employees/Edit/' + row.Id + '">Edit</a> | <a href="/Employees/Details/' + row.Id + '">Details</a> | <a href="/Employees/Delete/' + row.Id + '">Delete</a>';
                }, "orderable": false, "autoWidth": true
            }
        ]
    });
});