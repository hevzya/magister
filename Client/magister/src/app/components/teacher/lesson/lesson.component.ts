import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, TemplateRef, inject } from '@angular/core';
import { StudentModel } from '../../admin/admin-panel/admin-panel.component';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { API_URL, STUDENT_ROLE } from 'src/app/consts/consts';
import { OdataResult } from '../../utils/odataHelpers';
import { LessonModel } from '../../admin/admin-panel/entities/admin-lessons/admin-lessons.component';
import { VisitingModel } from '../../models/visiting';
import { NgbDateStruct, NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Claims, TokenService } from 'src/services/token.service';




@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent implements OnInit {

  private modalService = inject(NgbModal);


  readonly API_URL = 'https://localhost:7211/api/';
  public students: StudentModel[] = [];

  public visitings: VisitingModel[] = [];

  lessonId: string = '';
  lesson: LessonModel = {};

  endDate?: Date = new Date();

  homeworkDesc?: string;
  homeworkFile?: File;
  homeworkDeadline?: NgbDateStruct;

  claims: Claims = {};

  constructor(private http: HttpClient, private route: ActivatedRoute, private tokenService: TokenService, private router: Router) {

  }

  async ngOnInit(): Promise<void> {

    this.claims = this.tokenService.getClaims();

    if(this.claims.role == STUDENT_ROLE) {
      this.router.navigateByUrl('marks');
    }
    
    this.route.params.subscribe(async params => {
      this.lessonId = params['id'];
      console.log(this.lessonId);

      var lesson = await this.http.get<OdataResult>(API_URL + 'lessons?expand=Group&expand=Subject&expand=Teacher&filter=id eq ' + this.lessonId).toPromise();


      if (lesson) {
        this.lesson = lesson.value[0];

        this.endDate = new Date(this.lesson.lessonStartDate!);
        this.endDate.setMinutes(this.endDate.getMinutes() + this.lesson.duration!);

      }

      var students = await this.http.get<OdataResult>(API_URL + 'students?filter=groupid eq '+ this.lesson?.group?.id).toPromise();

      var visitings = await this.http.get<any[]>(API_URL + 'api/Visitings?lessonId='+this.lesson.id).toPromise();
      console.log(visitings);

      if(students) {
        this.students = students.value;

        students.value.forEach(student => {
          this.visitings.push({
            studentId: student?.id,
            lessonId: this.lesson.id,
            studentName: student.name + ' ' + student.surname,
            examMark: visitings?.find(x => x.studentId == student.id)?.examMark,
            isLate: visitings?.find(x => x.studentId == student.id)?.isLate,
            isPresent: visitings?.find(x => x.studentId == student.id)?.isPresent,
            lessonMark: visitings?.find(x => x.studentId == student.id)?.lessonMark,
          });
        });

        console.log(this.visitings);
      }

    });

   

  }

  async visitingChanged(visiting: VisitingModel) {
    console.log(visiting);
    await this.http.post(API_URL+ 'api/Visitings', visiting).toPromise();
  }

  addHomework(content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
			async (result) => { // when clicked save

        if (!this.homeworkFile) {
          return;
        }

        let formData: FormData = new FormData();
        formData.append('file', this.homeworkFile, this.homeworkFile.name)
        
        let headers = new HttpHeaders();

        headers.append('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');

        var deadline: Date = new Date(this.homeworkDeadline?.year!, this.homeworkDeadline?.month! - 1, this.homeworkDeadline?.day! + 1);
        
        var res = await this.http.post(API_URL + `api/Homework?description=${this.homeworkDesc}&deadline=${deadline.toISOString()}&lessonId=${this.lessonId}`, formData, { headers }).toPromise()

        // console.log(res);
			},
			(reason) => {
				//this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
			},
		);
  }


  async fileChange(event: any) {
    let fileList: FileList = event.target.files;
    
    if (fileList.length < 1) {
      return;
    }
    
    this.homeworkFile = fileList[0];


    ///////

    let file: File = fileList[0];
    let formData:FormData = new FormData();
    formData.append('uploadFile', file, file.name)
    
    let headers = new Headers();
    /** In Angular 5, including the header Content-Type can invalidate your request */
    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');

    // let options = new RequestOptions({ headers: headers });

    //var res = await this.http.post(`${this.apiEndPoint}`, formData).toPromise()
        
}


}
