//GiveAdd and OfferEdit Page 
document.querySelector("#countries").addEventListener("click", function () {
  swal({
    title: "Countries Information !",
    text: "Select the shipping country from the drop-down menu.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#city").addEventListener("click", function () {
  swal({
    title: "City Information !",
    text: "Helps you choose a city from the country of your choice.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#mode").addEventListener("click", function () {
  swal({
    title: "Mode Information !",
    text: "With the mod you can choose the type of transpor. FCL (Full Conatainer Load): " +
      " Standart 20 veya 40 konteynerin tamamını dolduracak kadar kargosu olan nakliyeciler tarafından tercih edilmektedir. " +
      " LCL (Less Container Load): You can send your cargo to any place you want by loading it in standard containers known as 20' and 40'. However, sometimes the cargo you send may not fill all of these standard containers and is considered as partial cargo. In such cases, you should prefer LCL loading. " +
      " Air: The option you should choose to send your cargo by air",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#movement").addEventListener("click", function () {
  swal({
    title: "Movement Type Information !",
    text: "You can choose the type of movement with the option closest to you.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#incoterm").addEventListener("click", function () {
  swal({
    title: "Incoterm Information !",
    text: "Payment method according to the shipping terms of international delivery.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#package").addEventListener("click", function () {
  swal({
    title: "Package Type Information !",
    text: "Types of packaging for delivery.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#unit1").addEventListener("click", function () {
  swal({
    title: "Unit-1 Information !",
    text: "You can choose the size type of your delivery",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#unit2").addEventListener("click", function () {
  swal({
    title: "Unit-2 Information !",
    text: "You can choose the weight type of your delivery.",
    icon: "info",
    button: "Okey !",
  });
});
document.querySelector("#currency").addEventListener("click", function () {
  swal({
    title: "Currency Information !",
    text: "Choose the international or national currency your shipment will travel to.",
    icon: "info",
    button: "Okey !",
  });
});

