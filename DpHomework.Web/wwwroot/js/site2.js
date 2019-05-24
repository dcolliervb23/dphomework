
$(document).ready(function () {

    $('#addBtn').on('click', function() {
        $.ajax({
            type: "POST",
            url: "http://localhost:64546/api/individual",
            data: {
                FirstName: $('#firstName').val(),
                MiddleName: $('#middleName').val(),
                LastName: $('#lastName').val(),
                Email: $('#email').val()
            },
            dataType: 'json',
//            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert('success');
            },
            error: function (data) {
                alert('error.  Please see Joe.');
            }
        });
    });

});