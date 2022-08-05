const noteComment = document.querySelector(".new-note-comment");
const noteColor = document.querySelector(".new-note-color");
const notePointId = document.querySelector(".new-note-pointId");

const addNewNote = document.querySelector(".notes__add");

var note = new Note();

noteComment.addEventListener("change", (e) => {
  if (!!note.stateNote.editNote.Comment) {
    return (note.stateNote.editNote.Comment = e.target.value);
  }
  return (note.stateNote.newNote.Comment = e.target.value);
});

noteColor.addEventListener("change", (e) => {
  if (!!note.stateNote.editNote.Color) {
    return (note.stateNote.editNote.Color = e.target.value);
  }
  return (note.stateNote.newNote.Color = e.target.value);
});

notePointId.addEventListener("change", (e) => {
  if (!!note.stateNote.editNote.PointId) {
    return (note.stateNote.editNote.PointId = e.target.value);
  }
  return (note.stateNote.newNote.PointId = e.target.value);
});

addNewNote.addEventListener("click", () => {
    if(!!note.stateNote.editNote.Comment || !!note.stateNote.editNote.Color || note.stateNote.editNote.PointId){
        note.UpdateNote();
    }
    else if(noteComment.value === '' || noteColor.value === '' || notePointId.value === '') {
        alert("Все поля должны быть обязательно заполнены!");
    }
    else {
        note.CreateNote();
    }

    CleanDataNote();
});

const CleanDataNote = () => {
    noteComment.value = '';
    noteColor.value = '';
    notePointId.value = '';
}