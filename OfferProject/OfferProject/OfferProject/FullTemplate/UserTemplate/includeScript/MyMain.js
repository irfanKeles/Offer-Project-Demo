//Login / Register Js
let input = document.querySelector("#loginRegisterpass");
let eye = document.querySelector('#loginRegistereye').addEventListener('click', function () {
  input.setAttribute("type", "text");
  setTimeout(function () {

    input.setAttribute("type", "password");
  }, 1500);
});
// OfferDetail
function onPoup(id) {
  console.log(id);
  OpenBootstrapPopup();
  function OpenBootstrapPopup() {
    $("#myModal_" + id).modal('show');
  }
};


