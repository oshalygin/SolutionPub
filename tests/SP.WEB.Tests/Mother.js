var Mother = (function () {

    return {
        getPosts: getPosts
    };

    function getPosts() {

        return {
            data: {
                value:
                [
                    {
                        id: 5,
                        title: "JavaScript Fundamentals",
                        urlTitle: "JavaScript-Fundamentals",
                        photoPath: "C:\dev\PhotoPath",
                        postedDate: "2015-10-28T05:20:30.9891138",
                        dateEdited: "0001-01-01T00:00:00",
                        body: "Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.<br><br>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis",
                        "preview": "oin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Pr",
                        views: 78,
                        tags: [],
                        comments: []
                    },
                    {
                        id: 6,
                        title: "AngularJS Routing",
                        urlTitle: "AngularJS-Routing",
                        photoPath: "C:\dev\PhotoPath",
                        postedDate: "2015-10-28T05:20:30.9891138",
                        dateEdited: "0001-01-01T00:00:00",
                        body: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis<br><br>Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.",
                        "preview": " elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Done",
                        views: 66,
                        tags: [],
                        comments: [
                            {
                                id: 2,
                                body: "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur",
                                dateOfComment: "2015-10-28T05:20:30.9891138",
                                name: null,
                                email: null,
                                isAnonymous: false
                            }
                        ]
                    },
                    {
                        id: 7,
                        title: "JavaScript Fundamentals",
                        urlTitle: "JavaScript-Fundamentals",
                        photoPath: "C:\dev\PhotoPath",
                        postedDate: "2015-10-28T05:20:30.9891138",
                        dateEdited: "0001-01-01T00:00:00",
                        body: "Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.<br><br>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis",
                        "preview": "oin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Pr",
                        views: 63,
                        tags: [],
                        comments: []
                    },
                    {
                        id: 8,
                        title: "AngularJS Routing",
                        urlTitle: "AngularJS-Routing",
                        photoPath: "C:\dev\PhotoPath",
                        postedDate: "2015-10-28T05:20:30.9891138",
                        dateEdited: "0001-01-01T00:00:00",
                        body: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis<br><br>Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.",
                        "preview": " elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Done",
                        views: 31,
                        tags: [],
                        comments: []
                    },
                    {
                        id: 9,
                        title: "JavaScript Fundamentals",
                        urlTitle: "JavaScript-Fundamentals",
                        photoPath: "C:\dev\PhotoPath",
                        postedDate: "2015-10-28T05:20:30.9891138",
                        dateEdited: "0001-01-01T00:00:00",
                        body: "Aenean sed fringilla lectus, vitae placerat mi. Proin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Proin in sem ac dolor vestibulum sodales a nec lacus. Praesent lectus quam, interdum a condimentum accumsan, congue in ante. Phasellus at mi euismod, mollis dui in, ornare nisl.<br><br>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae scelerisque tortor. Fusce ac augue in nulla lobortis auctor fringilla id urna. Aenean eleifend metus mi, non fringilla libero tempus ac. Curabitur vitae posuere ligula, ac faucibus ex. Cras placerat est lectus, condimentum dictum est volutpat quis. Proin bibendum vel tortor sit amet lobortis. Curabitur bibendum porttitor erat vel molestie. Morbi auctor cursus nisl et posuere. Donec ac placerat mauris, quis rutrum turpis",
                        "preview": "oin non ante interdum, congue metus dignissim, gravida enim. Praesent pulvinar vehicula sodales. In congue hendrerit vestibulum. Sed vitae interdum quam. Maecenas nec quam urna. Nulla sollicitudin, nisi a vulputate luctus, leo neque luctus turpis, quis ultrices mauris dui sit amet diam. Nunc imperdiet quam id lectus convallis, eget condimentum lorem consectetur. Sed dignissim bibendum ultrices. Pr",
                        views: 95,
                        tags: [],
                        comments: []
                    }
                ]
            }
        };
    }

})();