// Initialize AOS animation
AOS.init({ once: true });

//  Initialize Swiper
let swiper = new Swiper(".mySwiper", {
  slidesPerView: 1,
  spaceBetween: 10,
  loop: true,
  autoplay: {
    delay: 7000,
    disableOnInteraction: false,
  },
  breakpoints: {
    640: {
      slidesPerView: 2,
      spaceBetween: 20,
    },
    768: {
      slidesPerView: 1.6,
      spaceBetween: 20,
    },
    1024: {
      slidesPerView: 3,
      spaceBetween: 50,
    },
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
});

// nav bar effects on scroll
window.addEventListener("scroll", function () {
  const header = document.querySelector("header");
  header.classList.toggle("sticky", window.scrollY > 0);
});

//responsive sidebar menu
const menuBtn = document.querySelector(".menu-btn");
const menuBtn2 = document.querySelector(".menu-btn2");
const navigation = document.querySelector(".navigation");
const navigationItems = document.querySelectorAll(".navigation a");

menuBtn.addEventListener("click", () => {
  menuBtn.classList.toggle("active");
  navigation.classList.toggle("active");
  menuBtn2.classList.toggle("active");
});

navigationItems.forEach((navigationItem) => {
  navigationItem.addEventListener("click", () => {
    menuBtn.classList.remove("active");
    navigation.classList.remove("active");
  });
});

// // FOR THE TYPING ANIMATED TEXT

// // contents to type
// let aboutMsg = ["Front End Developer", "Back End Developer", "Game Developer"];

// // current sentence being printed out
// let msg = 0;

// // character of sentence being printed
// let msgChar = 0;

// // this holds the handle returned from setinterval
// let intervalVal;

// const text = document.querySelector("#text");
// const cursor = document.querySelector("#cursor");

// // typing effect
// const typing = () => {
//   // get substring and add 1 character everytime
//   let newText = aboutMsg[msg].substring(0, msgChar + 1);
//   text.innerHTML = newText;
//   msgChar++;

//   //delete sentence after its been completely displayed
//   if (text === aboutMsg[msg]) {
//     // hide the cursor
//     cursor.style.display = "none";
//     clearInterval(intervalVal);
//     setTimeout(function () {
//       intervalVal = setInterval(deleting, 50);
//     }, 1000);
//   }
// };

// // deleting effect
// const deleting = () => {
//   // substring with one char deleted
//   let newText = aboutMsg[msg].substring(0, msgChar - 1);
//   text.innerHTML = newText;
//   msgChar--;

//   // display the second sentence after the first has been deleted
//   if (text === "") {
//     clearInterval(intervalVal);

//     //if the current sentence being displayed is the last, move to the first one else move to the next
//     if (msg == aboutMsg.length - 1) {
//       msg = 0;
//     } else {
//       msg++;
//     }

//     msgChar = 0;

//     // display the next sentence after some time
//     setTimeout(function () {
//       cursor.style.display = "inline-block";
//       intervalVal = setInterval(typing, 100);
//     }, 100);
//   }
// };

// // start the typing effect on load
// intervalVal = setInterval(typing, 100);

// List of sentences
var aboutMsg = ["Front End Developer", "Back End Developer", "Game Developer"];

// Current sentence being processed
var msg = 0;

// Character number of the current sentence being processed
var msgChar = 0;

// Holds the handle returned from setInterval
var intervalVal;

// Element that holds the text
var text = document.querySelector("#text");

// Cursor element
var dcursor = document.querySelector("#cursor");

// Implements typing effect
function Type() {
  // Get substring with 1 characater added
  var newText = aboutMsg[msg].substring(0, msgChar + 1);
  text.innerHTML = newText;
  msgChar++;

  // If full sentence has been displayed then start to delete the sentence after some time
  if (newText === aboutMsg[msg]) {
    // Hide the cursor
    dcursor.style.display = "none";

    clearInterval(intervalVal);
    setTimeout(function () {
      intervalVal = setInterval(Delete, 50);
    }, 1000);
  }
}

// Implements deleting effect
function Delete() {
  // Get substring with 1 characater deleted
  var newText = aboutMsg[msg].substring(0, msgChar - 1);
  text.innerHTML = newText;
  msgChar--;

  // If sentence has been deleted then start to display the next sentence
  if (newText === "") {
    clearInterval(intervalVal);

    // If current sentence was last then display the first one, else move to the next
    if (msg == aboutMsg.length - 1) msg = 0;
    else msg++;

    msgChar = 0;

    // Start to display the next sentence after some time
    setTimeout(function () {
      dcursor.style.display = "inline-block";
      intervalVal = setInterval(Type, 100);
    }, 200);
  }
}

// Start the typing effect on load
intervalVal = setInterval(Type, 100);
