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
            .get('http://dphomework.azurewebsites.net/api/individual')
//            .get('http://localhost:64546/api/individual')
            .then(response => (this.info = response.data.data));
    }
});
