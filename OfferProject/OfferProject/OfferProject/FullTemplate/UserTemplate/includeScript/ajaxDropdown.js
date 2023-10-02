$(function () {
  let sel = document.createElement("select");
  sel.setAttribute("id", "city");
  $('#Country').change(function () {
    var id = $('#Country').val();

    $.ajax({
      url: '/userHome/city',
      data: { p: id },
      type: "POST",
      dataType: "Json",
      success: function (data) {
        $('#citydrp').empty();
        for (var i = 0; i < data.length; i++) {
          $('#citydrp').append("<option value='" + data[i].Value + "'>" + data[i].Text + "</Option>");
        };
      }
    });
  });
});
