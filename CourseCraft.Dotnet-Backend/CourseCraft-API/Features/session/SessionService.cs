public class SessionService
{
    public async Task<Result<SessionResponse[]>> GetAllSessions(int studentId)
    {
        await Task.Delay(500);
        if (studentId != 1)
            return Result<SessionResponse[]>.NotFound("Student not found.");

        var mockSessions = new[]
        {
            new SessionResponse(
                1,
                "Class 1",
                "Math",
                new DateTime(2023, 1, 1),
                """
                <!DOCTYPE html>
                    <html lang="en">
                    <head>
                        <meta charset="UTF-8">
                        <meta name="viewport" content="width=device-width, initial-scale=1.0">
                        <title>Lesson Mockup</title>

                        <style>
                            body{
                                font-family: Arial, Helvetica, sans-serif;
                                max-width: 700px;
                                margin: auto;
                                padding:20px;
                                line-height:1.4;
                            }

                            h1{
                                text-align:center;
                                margin-bottom:25px;
                            }

                            h2{
                                margin-top:40px;
                                border-bottom:2px solid #ddd;
                                padding-bottom:5px;
                            }

                            h3{
                                margin-top:25px;
                            }

                            .image-placeholder{
                                width:120px;
                                height:120px;
                                border:2px solid #bbb;
                                position:relative;
                                margin:15px;
                                flex-shrink:0;
                            }

                            .image-placeholder::before,
                            .image-placeholder::after{
                                content:"";
                                position:absolute;
                                width:100%;
                                height:2px;
                                background:#bbb;
                                top:50%;
                                left:0;
                            }

                            .image-placeholder::before{
                                transform:rotate(45deg);
                            }

                            .image-placeholder::after{
                                transform:rotate(-45deg);
                            }

                            .two-column{
                                display:flex;
                                gap:20px;
                                align-items:flex-start;
                            }

                            table{
                                width:100%;
                                border-collapse:collapse;
                                margin:20px 0;
                            }

                            th,td{
                                border:1px solid #000;
                                padding:8px;
                                text-align:center;
                            }

                            ul{
                                padding-left:20px;
                            }

                            .gallery{
                                display:flex;
                                gap:10px;
                                margin-top:15px;
                            }

                            .gallery .image-placeholder{
                                width:80px;
                                height:80px;
                                margin:0;
                            }

                            .small-image{
                                width:90px;
                                height:140px;
                            }
                        </style>
                    </head>

                    <body>

                    <h1>Lesson</h1>

                    <section class="two-column">

                        <div>

                            <h3>Lesson</h3>

                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                            </p>

                            <p>
                                Duis aute irure dolor in reprehenderit in voluptate velit esse
                                cillum dolore eu fugiat nulla pariatur.
                            </p>

                        </div>

                        <div class="image-placeholder"></div>

                    </section>

                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    </p>

                    <section>

                        <h2>Strategies</h2>

                        <ul>
                            <li>Quis nostrud exercitation ullamco.</li>
                            <li>Reprehenderit in voluptate velit.</li>
                            <li>Nisi ut aliquip ex ea commodo consequat.</li>
                        </ul>

                    </section>

                    <section>

                        <h2>Worksheet</h2>

                        <p>
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco
                            laboris nisi ut aliquip ex ea commodo consequat.
                        </p>

                        <table>

                            <tr>
                                <th>Header 1</th>
                                <th>Header 2</th>
                            </tr>

                            <tr>
                                <td>row 1 col 1</td>
                                <td>row 1 col 2</td>
                            </tr>

                            <tr>
                                <td>row 2 col 1</td>
                                <td>row 2 col 2</td>
                            </tr>

                        </table>

                        <h3>Heading</h3>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        </p>

                        <div class="image-placeholder" style="width:100%; height:140px;"></div>

                        <h3>Heading</h3>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        </p>

                        <div class="gallery">
                            <div class="image-placeholder"></div>
                            <div class="image-placeholder"></div>
                            <div class="image-placeholder"></div>
                        </div>

                    </section>

                    <section>

                        <h2>Learning Review Worksheet</h2>

                        <p>
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco
                            laboris nisi ut aliquip ex ea commodo consequat.
                        </p>

                        <table>

                            <tr>
                                <th>Heading</th>
                            </tr>

                        </table>

                        <section class="two-column">

                            <div>

                                <div class="image-placeholder"></div>

                                <h3>Heading</h3>

                                <p>
                                    Lorem ipsum dolor sit amet,
                                    consectetur adipiscing elit,
                                    sed do eiusmod tempor incididunt.
                                </p>

                            </div>

                            <div>

                                <h3>Heading</h3>

                                <p>
                                    Lorem ipsum dolor sit amet,
                                    consectetur adipiscing elit.
                                </p>

                                <div class="image-placeholder small-image"></div>

                            </div>

                        </section>

                    </section>

                    </body>
                    </html>
                """
                ,
                0
            ),
            new SessionResponse(
                2,
                "Class 1",
                "Science",
                new DateTime(2023, 1, 2),
                  """
                <!DOCTYPE html>
                    <html lang="en">
                    <head>
                        <meta charset="UTF-8">
                        <meta name="viewport" content="width=device-width, initial-scale=1.0">
                        <title>Lesson Mockup</title>

                        <style>
                            body{
                                font-family: Arial, Helvetica, sans-serif;
                                max-width: 700px;
                                margin: auto;
                                padding:20px;
                                line-height:1.4;
                            }

                            h1{
                                text-align:center;
                                margin-bottom:25px;
                            }

                            h2{
                                margin-top:40px;
                                border-bottom:2px solid #ddd;
                                padding-bottom:5px;
                            }

                            h3{
                                margin-top:25px;
                            }

                            .image-placeholder{
                                width:120px;
                                height:120px;
                                border:2px solid #bbb;
                                position:relative;
                                margin:15px;
                                flex-shrink:0;
                            }

                            .image-placeholder::before,
                            .image-placeholder::after{
                                content:"";
                                position:absolute;
                                width:100%;
                                height:2px;
                                background:#bbb;
                                top:50%;
                                left:0;
                            }

                            .image-placeholder::before{
                                transform:rotate(45deg);
                            }

                            .image-placeholder::after{
                                transform:rotate(-45deg);
                            }

                            .two-column{
                                display:flex;
                                gap:20px;
                                align-items:flex-start;
                            }

                            table{
                                width:100%;
                                border-collapse:collapse;
                                margin:20px 0;
                            }

                            th,td{
                                border:1px solid #000;
                                padding:8px;
                                text-align:center;
                            }

                            ul{
                                padding-left:20px;
                            }

                            .gallery{
                                display:flex;
                                gap:10px;
                                margin-top:15px;
                            }

                            .gallery .image-placeholder{
                                width:80px;
                                height:80px;
                                margin:0;
                            }

                            .small-image{
                                width:90px;
                                height:140px;
                            }
                        </style>
                    </head>

                    <body>

                    <h1>Lesson</h1>

                    <section class="two-column">

                        <div>

                            <h3>Lesson</h3>

                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                            </p>

                            <p>
                                Duis aute irure dolor in reprehenderit in voluptate velit esse
                                cillum dolore eu fugiat nulla pariatur.
                            </p>

                        </div>

                        <div class="image-placeholder"></div>

                    </section>

                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    </p>

                    <section>

                        <h2>Strategies</h2>

                        <ul>
                            <li>Quis nostrud exercitation ullamco.</li>
                            <li>Reprehenderit in voluptate velit.</li>
                            <li>Nisi ut aliquip ex ea commodo consequat.</li>
                        </ul>

                    </section>

                    <section>

                        <h2>Worksheet</h2>

                        <p>
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco
                            laboris nisi ut aliquip ex ea commodo consequat.
                        </p>

                        <table>

                            <tr>
                                <th>Header 1</th>
                                <th>Header 2</th>
                            </tr>

                            <tr>
                                <td>row 1 col 1</td>
                                <td>row 1 col 2</td>
                            </tr>

                            <tr>
                                <td>row 2 col 1</td>
                                <td>row 2 col 2</td>
                            </tr>

                        </table>

                        <h3>Heading</h3>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        </p>

                        <div class="image-placeholder" style="width:100%; height:140px;"></div>

                        <h3>Heading</h3>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                        </p>

                        <div class="gallery">
                            <div class="image-placeholder"></div>
                            <div class="image-placeholder"></div>
                            <div class="image-placeholder"></div>
                        </div>

                    </section>

                    <section>

                        <h2>Learning Review Worksheet</h2>

                        <p>
                            Ut enim ad minim veniam, quis nostrud exercitation ullamco
                            laboris nisi ut aliquip ex ea commodo consequat.
                        </p>

                        <table>

                            <tr>
                                <th>Heading</th>
                            </tr>

                        </table>

                        <section class="two-column">

                            <div>

                                <div class="image-placeholder"></div>

                                <h3>Heading</h3>

                                <p>
                                    Lorem ipsum dolor sit amet,
                                    consectetur adipiscing elit,
                                    sed do eiusmod tempor incididunt.
                                </p>

                            </div>

                            <div>

                                <h3>Heading</h3>

                                <p>
                                    Lorem ipsum dolor sit amet,
                                    consectetur adipiscing elit.
                                </p>

                                <div class="image-placeholder small-image"></div>

                            </div>

                        </section>

                    </section>

                    </body>
                    </html>
                """,
                0
            )
        };

        return Result<SessionResponse[]>.Success(mockSessions);
    }
}