class Note {
  url = variables.API_URL;

  stateNote = {
    notes: [],
    newNote: {
      Comment: " ",
      Color: "white",
      PointId: 0,
    },
    editNote: {},
  };

  stateKonva = {
    konvaRec: [],
    textNotes: [],
  };

  constructor() {
    fetch(this.url + "Notes/getAllNotes", {
      method: "GET",
    })
      .then((res) => res.json())
      .then(
        (notes) => (this.stateNote.notes = this.stateNote.notes.concat(notes))
      )
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  GetNotes() {
    fetch(`${this.url}Notes/getAllNotes`, {
      method: "GET",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then(
        (notes) => (this.stateNote.notes = this.stateNote.notes.concat(notes))
      )
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    return this.stateNote.notes;
  }

  GetNotesPointId(pointId) {
    let defNotes = [];

    for (let i = 0; i < this.stateNote.notes.length; i++) {
      if (this.stateNote.notes[i].PointId == pointId)
        defNotes.push(this.stateNote.notes[i]);
    }

    return defNotes;
  }

  CreateNote() {
    return fetch(this.url + "Notes/insertNote", {
      method: "POST",
      body: JSON.stringify(this.stateNote.newNote),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then((id) =>
        this.stateNote.notes.push({
          Id: id,
          Comment: this.stateNote.newNote.Comment,
          Color: this.stateNote.newNote.Color,
          PointId: Number(this.stateNote.newNote.PointId),
        })
      )
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  DrawNote(index) {
    let layer = new Konva.Layer();

    let itemPoint = point.statePoint.points[index];

    let space = 20;

    let tempRec = [];
    let tempText = [];

    let defNotes = this.GetNotesPointId(itemPoint.Id);

    for (let i = 0; i < defNotes.length; i++) {
      let itemNote = defNotes[i];

      tempText[i] = new Konva.Text({
        x: itemPoint.x_Axis - itemPoint.Radius,
        y: itemPoint.y_Axis + space * i + itemPoint.Radius + 5,
        fontSize: 18,
        text: itemNote.Comment,
        height: 20,
      });

      tempRec[i] = new Konva.Rect({
        x: tempText[i].x(),
        y: tempText[i].y(),
        fill: itemNote.Color,
        stroke: "black",
        width: tempText[i].width() + 30,
        height: 20,
      });

      tempRec[i].on("dblclick", () => {
        this.DeleteNote(defNotes[i].Id, tempRec[i], tempText[i]);
      });

      tempText[i].on("click", () => {
        this.stateNote.editNote = defNotes[i];

        noteComment.value = defNotes[i].Comment;
        noteColor.value = defNotes[i].Color;
        notePointId.value = defNotes[i].PointId;
      });

      layer.add(tempRec[i]);
      layer.add(tempText[i]);
    }

    this.stateKonva.konvaRec[index] = tempRec;
    this.stateKonva.textNotes[index] = tempText;

    return layer;
  }

  TurnToZero(id) {
    for (let i = 0; i < this.stateNote.notes.length; i++) {
      if (this.stateNote.notes[i].Id == id) {
        this.stateNote.notes[i] = 0;
        this.stateNote.notes.slice(i, 1);
        return;
      }
    }
  }

  DeleteNote(noteId, rec, text) {
    fetch(this.url + `Notes/deleteNote?id=${noteId}`, {
      method: "DELETE",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then((res) => {
        if (res == true) {
          rec.destroy();
          text.destroy();

          this.TurnToZero(noteId);
        }
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  UpdateNote() {
    fetch(this.url + `Notes/updateNote`, {
      method: "PUT",
      body: JSON.stringify(this.stateNote.editNote),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => res.json())
      .then((res) => res)
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    this.stateNote.editNote = {};
  }
}
