function ShowDeletePopup(UserID, message) {
    $('.bootbox-body').html(message);
    $('.bootbox-body').removeClass('alert alert-danger fade in').removeClass('alert alert-success fade in');
    $('.modal-footer').show();
    $('#deleteModal').modal('show');
    $('#deleteModal').attr('data-id', UserID);
}

$('#delete-ok').click(function () {
    Delete();

});

$('#btn-close').click(function () {
    $('.bootbox-close-button').click();
});

function Delete() {
    var UserID = $('#deleteModal').attr('data-id');
    var trid = "#row-" + UserID;
    var url = "/student/Delete?UserID=" + encodeURI(UserID);
    $.getJSON(url)
   .done(function (json) {
       var message = json.message;
       $('.bootbox-body').css('margin-top', 18);
       if (json.isDeleted) {
           $('.bootbox-body').addClass('alert alert-success fade in');
           $('.bootbox-body').html(message);
           $(trid).hide();
           setTimeout(function () {
               $('.bootbox-close-button').click();
               window.location.href = "/student/students";
           }, 3000);
       }
       else {
           $('.bootbox-body').addClass('alert alert-danger fade in');
           $('.bootbox-body').html(message);
       }
       $('.modal-footer').hide();

   })
}

$(".btnCancel").click(function () {
    location.href = "/Student/Students";
});