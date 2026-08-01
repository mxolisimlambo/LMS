$(function () {
    console.log('App Started');

    try {
        console.log('Before Layout');

        Layout.initialize()
            .then(function () {
                console.log('After Layout');

                console.log('Before PageRegistry');

                PageRegistry.initialize();

                console.log('After PageRegistry');
            })
            .catch(function (error) {
                console.error('Layout Error');

                console.error(error);
            });
    } catch (error) {
        console.error('App Error');

        console.error(error);
    }
});
