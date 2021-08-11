Ext.define('HostelApp.view.reservation.ReservationView',{
    extend: 'Ext.grid.Grid',
    xtype: 'reservationview',
    cls: 'reservationview',
    controller: {type: 'reservationviewcontroller'},
    viewModel: {type: 'reservationviewmodel'},
    store: {type: 'reservationApi'},
    grouped: true,
    groupFooter: {
        xtype: 'gridsummaryrow'
    },
    columns: [
        {
            text: 'Kod rezerwacji',
            dataIndex: 'ReservationCode',
            editable: false,
            flex: 1
        },
        {
            text: 'Utworzono',
            dataIndex: 'CreatedAt',
            editable: false,
            xtype: 'datecolumn',
            flex: 1
        },
        {
            text: 'Cena',
            dataIndex: 'Price',
            editable: false,
            xtype: 'numbercolumn',
            format: '0.00',
            flex: 1
        },
        {
            text: 'Zameldowanie',
            dataIndex: 'CheckInDate',
            editable: false,
            xtype: 'datecolumn',
            flex: 1
        },
        {
            text: 'Wymeldowanie',
            dataIndex: 'CheckOutDate',
            editable: false,
            flex: 1
        },
        {
            text: 'Waluta',
            dataIndex: 'CurrencyType',
            editable: false,
            flex: 1
        },
        {
            text: 'Prowizja',
            dataIndex: 'Commission',
            editable: false,
            xtype: 'numbercolumn',
            format: '0.00',
            flex: 1
        },
        {
            text: 'Źródło',
            dataIndex: 'Source',
            editable: false,
            flex: 1
        }
    ]
});
