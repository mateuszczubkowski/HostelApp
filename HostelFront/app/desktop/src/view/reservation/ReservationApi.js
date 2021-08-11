Ext.define('HostelApp.view.reservation.ReservationApi', {
    extend: 'Ext.data.Store',
    alias: 'store.reservationApi',
    // fields: [
    //     'reservationCode', 'createdAt', 'price', 'checkInDate', 'checkOutDate', 'currencyType', 'comission', 'source'
    // ],
    proxy: {
        type: 'ajax',
        url: 'https://localhost:44308/api/reservation'
    },
    autoLoad: true
});