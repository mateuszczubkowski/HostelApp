Ext.define('HostelApp.view.home.HomeView',{
	xtype: 'homeview',
	cls: 'homeview',
	controller: {type: 'homeviewcontroller'},
	viewModel: {type: 'homeviewmodel'},
	requires: [],
	extend: 'Ext.Container',
  scrollable: true,
  html: `<div style="user-select: text !important;">This is simple web page created with ExtJs to present reservation list fetched from database.
  <br><br>
  To display reservation list select option 'Reservation' in the menu on the left.
  <br><br>
  If there is problem with fetching data, make sure to check api url (ReservationApi.js).
  I had problem with CORS and had to disable them in browser :(
<br><br>
</div>`
});