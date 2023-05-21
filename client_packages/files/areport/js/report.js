const vopros = (id, admin, ans, ques) => ({id, admin, ans, ques})

var areportpanel = new Vue({
  el: "#app",
  data: {
    active: false,
    answer: null,
    answers: [],
    text: null,
  },
  methods: {
    selectanswer(answer) {
      this.answer = answer;
    },
    clearAll() {
      this.answer = null;
      this.answers = [];
    },
    deleteAnswer(answer) {
      const index = this.answers.findIndex(n => n.id === answer.id);
      if (index !== -1) {
        this.answers.splice(index, 1);
      }
    },
    closepanel() {
      this.active = false;
      mp.trigger("closeReportPanel");
    },
    submit(report) {
      if(this.text != null && this.text.length > 5 || this.viewtype != '')
        mp.invoke("command", report + ` ` + this.text);
        this.text = null;
    },
    loadreply(json) {
      this.answers.unshift(vopros(json[0], json[1], json[2], json[3]));
    },
  },
  computed: {
    fixnullanswer() {
      if(this.answer == null){
        this.answer = {"id":"","admin":"","ans":"","ques":""};
      }
    }
  }
})
