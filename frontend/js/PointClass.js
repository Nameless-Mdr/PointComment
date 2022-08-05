class Point {
  url = variables.API_URL;

  statePoint = {
    points: [],
    newPoint: {
      x_Axis: 0,
      y_Axis: 0,
      Radius: 0,
      Color: "white",
    },
  };

  _stage;
  _layer;

  stateKonva = {
    circles: [],
    pointLayer: [],
  };

  constructor() {
    fetch(`${this.url}Points/getAllPoints`, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then(
        (points) =>
          (this.statePoint.points = this.statePoint.points.concat(points))
      )
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  GetPoints() {
    fetch(`${this.url}Points/getAllPoints`, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then(
        (points) =>
          (this.statePoint.points = this.statePoint.points.concat(points))
      )
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    return this.statePoint.points;
  }

  CreatePoint() {
    return fetch(this.url + "Points/insertPoint", {
      method: "POST",
      body: JSON.stringify(this.statePoint.newPoint),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then((id) => {
        if (id > 0) {
          this.statePoint.points.push({
            Id: id,
            x_Axis: Number(this.statePoint.newPoint.x_Axis),
            y_Axis: Number(this.statePoint.newPoint.y_Axis),
            Radius: Number(this.statePoint.newPoint.Radius),
            Color: this.statePoint.newPoint.Color,
          });
        }
      })
      .then(() => console.log(this.statePoint.points))
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  DrawPoint() {
    if (this._stage == null) {
      this._stage = new Konva.Stage({
        height: 800,
        width: 800,
        container: "konva-holder",
      });

      this._layer = new Konva.Layer();
      this._stage.add(this._layer);

      for (let i = 0; i < this.statePoint.points.length; i++) {
        if (this.statePoint.points[i] == 0) {
          this.statePoint.points.splice(i, 1);
          continue;
        }

        let item = this.statePoint.points[i];

        this.stateKonva.circles[i] = new Konva.Circle({
          x: item.x_Axis,
          y: item.y_Axis,
          radius: item.Radius,
          fill: item.Color,
          stroke: item.Color,
        });

        this._layer.add(this.stateKonva.circles[i]);
        this._layer.draw();

        this.stateKonva.circles[i]
          .on("dblclick", () => {
            fetch(
              `${this.url}Points/deletePoint?id=${this.statePoint.points[i].Id}`,
              {
                method: "DELETE",
                headers: {
                  "Content-type": "application/json; charset=UTF-8",
                },
              }
            )
              .then((res) => res.json())
              .then((res) => {
                if (res == true) {
                  this.statePoint.points[i] = 0;
                  this.stateKonva.circles[i].destroy();
                }
              })
              .catch((error) => {
                console.log(error);
                alert(error);
              });
          })
          .on("click", () => {
            if (this.stateKonva.pointLayer[i] == null) {
              this.stateKonva.pointLayer[i] = note.DrawNote(i);
              this._stage.add(this.stateKonva.pointLayer[i]);
              this.stateKonva.pointLayer[i].draw();
            } else {
              this.stateKonva.pointLayer[i].destroy();
              this.stateKonva.pointLayer[i] = null;
            }
          });
      }
    } else {
      for (let i = 0; i < this.stateKonva.pointLayer.length; i++) {
        if (this.stateKonva.pointLayer[i] != null) {
          this.stateKonva.pointLayer[i].destroy();
          this.stateKonva.pointLayer[i] = null;
        }
      }

      this._layer.destroy();
      this._layer = null;

      this._stage.destroy();
      this._stage = null;
    }
  }
}
