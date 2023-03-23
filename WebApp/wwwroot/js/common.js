let commonfn = window.commonfn || {}

commonfn.uuidv4 = function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

commonfn.mainpage = function (pageid) {
    window.mainid = pageid;
    window[pageid] = [];
}

let commonname = window.commonname || {}

commonname.sortclass = {
    ASC: "fas fa-light fa-caret-down",
    DESC: "fas fa-light fa-caret-up",
}
