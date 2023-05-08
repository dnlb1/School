const app = Vue.createApp({
    data() {
        return {
            CreateForm: false,
            hideb: true
        }
    },
    methods: {
        ShowCF() {
            this.CreateForm = !this.CreateForm;
            this.hideb = !this.hideb;
        }
    }
});
app.mount('#container')