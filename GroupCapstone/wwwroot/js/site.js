function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");     // Add :active modifier to button while dropdown is visible
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
       if (document.getElementsByClassName("dropdown-content").classList.contains('show')) {
         document.getElementById("dropdown-content").classList.remove('show');
       }
    }
  }
