// Write your JavaScript code.
new Vue({
    el: '#app',
    data() {
        return {
            info: null
        }
    },
    mounted() {
        axios
            .get('http://localhost:64546/api/individual')
//            .get('https://api.coindesk.com/v1/bpi/currentprice.json')
            .then(response => (this.info = response.data))
    }
})