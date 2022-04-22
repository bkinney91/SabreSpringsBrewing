import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { injectable, inject } from "inversify";

@injectable()
export class BrewEventService {

    private yeastStart = 7;
    private yeastEnd = 10;
    private coldCrashStart = 8;
    private coldCrashEnd = 12;
    private forceCarbStart = 9;
    private forceCarbEnd = 13;
    private packageStart = 10;
    private packageEnd = 14;
    private dryHopDaysBeforePackaging = 7;
    private dryHopStart = 8;
    private dryHopEnd = 11;

    public getYeastDumpDateStart(dateBrewed: Date,): Date {
        let yeastDumpDateStart: Date;   
        yeastDumpDateStart = new Date(dateBrewed);
        yeastDumpDateStart.setDate(yeastDumpDateStart.getDate() + this.yeastStart);
        return yeastDumpDateStart;
    }

    public getYeastDumpDateEnd(dateBrewed: Date,): Date {
        let yeastDumpDateEnd: Date;       
        yeastDumpDateEnd = new Date(dateBrewed);
        yeastDumpDateEnd.setDate(yeastDumpDateEnd.getDate() + this.yeastEnd);
        return yeastDumpDateEnd;
    }

    public getDryHopDateStart(dateBrewed: Date,): Date {
        let dryHopDateStart: Date;   
        dryHopDateStart = new Date(dateBrewed);
        dryHopDateStart.setDate(dryHopDateStart.getDate() + this.dryHopStart);
        return dryHopDateStart;
    }

    public getDryHopDateEnd(dateBrewed: Date,): Date {
        let dryHopDateEnd: Date;       
        dryHopDateEnd = new Date(dateBrewed);
        dryHopDateEnd.setDate(dryHopDateEnd.getDate() + this.dryHopEnd);
        return dryHopDateEnd;
    }

    public getColdCrashDateStart(dateBrewed: Date, style: string): Date {
        let coldCrashDateStart: Date;
        let days = this.coldCrashStart;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        coldCrashDateStart = new Date(dateBrewed);
        coldCrashDateStart.setDate(coldCrashDateStart.getDate() + days);
        return coldCrashDateStart;
    }

    public getColdCrashDateEnd(dateBrewed: Date, style: string): Date {
        let coldCrashDateEnd: Date;
        let days = this.coldCrashEnd;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        coldCrashDateEnd = new Date(dateBrewed);
        coldCrashDateEnd.setDate(coldCrashDateEnd.getDate() + days);
        return coldCrashDateEnd;
    }

 public getForceCarbonationDateStart(dateBrewed: Date, style: string): Date {
        let forceCarbonationDateStart: Date;
        let days = this.forceCarbStart;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        forceCarbonationDateStart = new Date(dateBrewed);
        forceCarbonationDateStart.setDate(forceCarbonationDateStart.getDate() + days);
        return forceCarbonationDateStart;
    }

    public getForceCarbonationDateEnd(dateBrewed: Date, style: string): Date {
        let getForceCarbonationDateEnd: Date;
        let days = this.forceCarbEnd;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        getForceCarbonationDateEnd = new Date(dateBrewed);
        getForceCarbonationDateEnd.setDate(getForceCarbonationDateEnd.getDate() + days);
        return getForceCarbonationDateEnd;
    }

   
    public getPackageDateStart(dateBrewed: Date, style: string): Date {
        let packageDateStart: Date;
        let days = this.packageStart;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        packageDateStart = new Date(dateBrewed);
        packageDateStart.setDate(packageDateStart.getDate() + days);
        return packageDateStart;
    }

    public getPackageDateEnd(dateBrewed: Date, style: string): Date {
        let packageDateEnd: Date;
        let days = this.packageEnd;
        if(style.includes("IPA")){
            days += this.dryHopDaysBeforePackaging;
        }
        packageDateEnd = new Date(dateBrewed);
        packageDateEnd.setDate(packageDateEnd.getDate() + days);
        return packageDateEnd;
    }

    public getScheduledPackage(dateBrewed: Date, style: string): string | null {
        let packageDateStart: Date = this.getPackageDateStart(dateBrewed, style);
        let packageDateEnd: Date = this.getPackageDateEnd(dateBrewed, style);
        return (
            packageDateStart.toLocaleDateString("en-US", { month: "numeric", day: "numeric" }) +
            " to " +
            
            packageDateEnd.toLocaleDateString("en-US", { month: "numeric", day: "numeric" })
        );
    }

    public getScheduledColdCrash(dateBrewed: Date, style: string): string | null {
        let scheduledColdCrashStart: Date = this.getColdCrashDateStart(dateBrewed, style);
        let scheduledColdCrashEnd: Date = this.getColdCrashDateEnd(dateBrewed, style);
        return (
            scheduledColdCrashStart.toLocaleDateString("en-US", { month: "numeric", day: "numeric" }) +
            " to " +
            scheduledColdCrashEnd.toLocaleDateString("en-US", { month: "numeric", day: "numeric" })
        );
    }

    public getScheduledForceCarbonation(dateBrewed: Date, style: string): string | null {
        let forceCarbonateStart: Date = this.getForceCarbonationDateStart(dateBrewed, style);
        let forceCarbonateEnd: Date = this.getForceCarbonationDateEnd(dateBrewed, style);
        return (
            forceCarbonateStart.toLocaleDateString("en-US", { month: "numeric", day: "numeric" }) +
            " to " +
            forceCarbonateEnd.toLocaleDateString("en-US", { month: "numeric", day: "numeric" })
        );
    }



    public getScheduledYeastDump(dateBrewed: Date): string | null {
        let yeastDumpDateStart: Date = this.getYeastDumpDateStart(dateBrewed);
        let yeastDumpDateEnd: Date = this.getYeastDumpDateEnd(dateBrewed);
        return (
            yeastDumpDateStart.toLocaleDateString("en-US", { month: "numeric", day: "numeric" }) +
            " to " +
            yeastDumpDateEnd.toLocaleDateString("en-US", { month: "numeric", day: "numeric" })
        );
    }

    public getScheduledDryHop(dateBrewed: Date): string | null {
        let dryHopDateStart: Date = this.getDryHopDateStart(dateBrewed);
        let dryHopDateEnd: Date = this.getDryHopDateEnd(dateBrewed);
        return (
            dryHopDateStart.toLocaleDateString("en-US", { month: "numeric", day: "numeric" }) +
            " to " +
            dryHopDateEnd.toLocaleDateString("en-US", { month: "numeric", day: "numeric" })
        );
    }


}