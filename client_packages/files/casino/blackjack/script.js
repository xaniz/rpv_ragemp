var vm = new Vue({
  el: "#app",
  data: {
    displayGet: false,
    displayStop: false,
    count: 51,
    distributeCount: 0,
    playerScore: 0,
    computerScore: 0,
    winner: "",
    player: [],
    computer: [],
    symbols: [
      { label: "spades", symbol: "♠" },
      { label: "hearts", symbol: "♥" },
      { label: "diamonds", symbol: "♦" },
      { label: "clubs", symbol: "♣" }
    ],
    cards: []
  },
  created() {
    this.getCards();
    this.shuffle();
  },
  methods: {
    getCards() {
      let cards = [];
      let num;
      for (i = 1; i <= 52; i++) {
        num = i % 13;
        if (num == 11) {
          num = "J";
        } else if (num == 12) {
          num = "Q";
        } else if (num == 0) {
          num = "K";
        } else if (num == 1) {
          num = "A";
        }

        cards.push({
          label: this.symbols[Math.floor((i - 1) % 4)].symbol,
          number: num,
          open: false,
          distribute: null,
          distributeCount: 0
        });
      }
      this.cards = cards;
    },
    shuffle() {
      this.cards.sort((a, b) => (Math.random() > 0.5 ? 1 : -1));
    },
    startGame() {
      this.restart();
      setTimeout(() => {
        this.displayGet = true;
        this.displayStop = true;
        this.player[this.player.length] = this.cards[this.count];
        this.cards[this.count].distributeCount = ++this.distributeCount;
        this.cards[this.count].open = true;
        this.cards[this.count--].distribute = "player";
        this.computer[this.computer.length] = this.cards[this.count];
        this.cards[this.count].distributeCount = this.distributeCount;
        this.cards[this.count--].distribute = "computer";
        mp.trigger("client::ruletzavrti", 100);
      }, 500);
    },
    getCard() {
      this.getNewCard(this.player);
      if (this.checkBoom(this.player)) {
        this.displayGet = false;
        this.displayStop = false;
        this.winner = "Diler";
        this.computer[0].open = true;
      }
    },
    izlaz() {
      mp.trigger("Hide_Crafting_System");
    },
    getNewCard(player) {
      this.cards[this.count].open = true;
      if (player == this.player) {
        player[player.length] = this.cards[this.count];
        this.cards[this.count].distribute = "player";
        this.cards[this.count--].distributeCount = ++this.distributeCount;
      } else {
        player[player.length] = this.cards[this.count];
        this.cards[this.count].distribute = "computer";
        this.cards[this.count--].distributeCount = ++this.distributeCount;
      }
    },
    stopGetCard() {
      this.displayGet = false;
      this.displayStop = false;
      this.distributeCount = 1;
      while (this.computerScore < this.playerScore) {
        this.getNewCard(this.computer);
        if (this.checkBoom(this.computer)) {
          this.computer[0].open = true;
          this.winner = "Ti";
          mp.trigger("client::ruletpobeda", 150);
        }
      }
      if (!this.winner) {
        this.calcScore();
      }
    },
    checkBoom(cards) {
      let sum = 0;
      cards.forEach((card) => {
        if (card.number == "J" || card.number == "Q" || card.number == "K") {
          sum += 10;
        } else if (card.number == "A" && sum + 11 == 21) {
          sum += 11;
        } else if (card.number == "A") {
          sum += 1;
        } else {
          sum += card.number;
        }
        if (sum == 11 && cards[0].number == "A") {
          sum = 21;
        }
      });
      if (cards == this.player) {
        this.playerScore = sum;
      } else {
        this.computerScore = sum;
      }
      if (sum > 21) {
        return true;
      } else {
        return false;
      }
    },
    calcScore() {
      this.computer[0].open = true;
      if (this.playerScore > this.computerScore) {
        this.winner = "Ti";
      } else if (this.playerScore < this.computerScore) {
        this.winner = "Diler";
      } else {
        this.winner = "Niko";
      }
    },
    restart() {
      this.cards = [];
      this.player = [];
      this.computer = [];
      this.getCards();
      this.shuffle();
      this.winner = "";
      this.distributeCount = 0;
      this.count = 51;
      this.playerScore = 0;
      this.computerScore = 0;
    }
  }
});