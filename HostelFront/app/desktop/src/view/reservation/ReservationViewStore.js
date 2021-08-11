Ext.define('HostelApp.view.reservation.ReservationViewStore', {
    extend: 'Ext.data.Store',
    alias: 'store.reservationviewstore',
    fields: [
        'reservationCode', 'createdAt', 'price', 'checkInDate', 'checkOutDate', 'currencyType', 'comission', 'source'
    ],
    groupField: 'dept',
    data: { items: [
        { reservationCode: 'ABCD', createdAt: '12-12-12', price: '123', checkInDate: '12-12-1', checkOutDate: '12-12-1', currencyType: 'EUR', comission: '12', source: 'abvf' },
        { reservationCode: 'ABCD', createdAt: '12-12-12', price: '123', checkInDate: '12-12-1', checkOutDate: '12-12-1', currencyType: 'EUR', comission: '12', source: 'abvf' }
    ]},
    proxy: {
        type: 'memory',
        reader: {
            type: 'json',
            rootProperty: 'items'
        }
    },
});
