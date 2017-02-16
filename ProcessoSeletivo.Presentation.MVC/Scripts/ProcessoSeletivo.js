function showConfirmModal(title, message, yesCallback) {
    $('#myModal #btnYes').click(yesCallback);
    $('#myModal #myModalTitle').text(title);
    $('#myModal #myModalMessage').text(message);
    $('#myModal').modal('show');
}


function showAlert(message, type) {
    var myAlert = $('#myAlert');
    myAlert.removeClass();
    myAlert.addClass('alert');
    myAlert.addClass('alert-' + type);
    myAlert.text(message);

    myAlert.fadeIn(500).slideDown(500);

    window.setTimeout(function () { myAlert.fadeOut(500).slideUp(500) }, 5000);
}

function showLoading() {
    $('#loadingModal').modal('show');
}

function hideLoading() {
    $('#loadingModal').modal('hide');
}



