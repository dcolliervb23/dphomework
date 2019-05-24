
$(document).ready(function () {

    $('#addBtn').on('click', function() {
        $.ajax({
            type: "POST",
            url: "http://dphomework.azurewebsites.net/api/address",
//            url: "http://localhost:64546/api/address",
            data: {
                AddressLine1: $('#addressLine1').val(),
                AddressLine2: $('#addressLine2').val(),
                City: $('#city').val(),
                State: $('#state').val(),
                Zip: $('#zip').val(),
                IndividualId: $('#individualId').val()

            },
            dataType: 'json',
            success: function (data) {
                alert('success');
            },
            error: function (data) {
                alert('error.  Please see Joe.');
            }
        });
    });

});