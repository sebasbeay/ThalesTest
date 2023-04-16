function searchEmployees() {
    var idEmployee = $("#txtEmployeeId").val();

    $.ajax({
        url: "/Home/FilterEmployee",
        dataType: "json",
        data: { idEmployee: idEmployee },
        type: "GET",
        success: function (arr) {
            console.log('employees', arr);
            $("#tbody-employees").empty();
            if (arr.status === "success") {
                if (arr.data === null) {
                    alert("That employee doesn't exist in our database");
                } else {
                    for (let employee of arr.data) {
                        $("#tbody-employees").append(
                            '<tr><td>' + employee.employee_name +
                            '</td><td>' + employee.employee_salary +
                            '</td><td>' + employee.employee_age +
                            '</td><td>' + employee.employee_anual_salary +
                            '</td><td>' + employee.profile_image +
                            '</td></tr>');
                    }
                }
            } else {
                alert(arr.message);
            }
        },
        error: function (data) {

        }
    });
}